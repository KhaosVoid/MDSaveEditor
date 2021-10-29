[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [String]$CSProjPath,

    [Switch]$Silent,

    [Parameter(ParameterSetName = 'getAuthors')]
    [Switch]$GetAuthors,

    [Parameter(ParameterSetName = 'getCompany')]
    [Switch]$GetCompany,

    [Parameter(ParameterSetName = 'getProduct')]
    [Switch]$GetProduct,

    [Parameter(ParameterSetName = 'getDescription')]
    [Switch]$GetDescription,

    [Parameter(ParameterSetName = 'getCopyright')]
    [Switch]$GetCopyright,

    [Parameter(ParameterSetName = 'getVersion')]
    [Switch]$GetVersion,

    [Parameter(ParameterSetName = 'setAssemblyInfo')]
    [String]$Authors,

    [Parameter(ParameterSetName = 'setAssemblyInfo')]
    [String]$Company,

    [Parameter(ParameterSetName = 'setAssemblyInfo')]
    [String]$Product,

    [Parameter(ParameterSetName = 'setAssemblyInfo')]
    [String]$Description,

    [Parameter(ParameterSetName = 'setAssemblyInfo')]
    [String]$Copyright,

    [Parameter(ParameterSetName = 'setAssemblyInfo')]
    [Switch]$AppendCopyrightYear
)

[String]$script:inputFilePath = $null
[String]$script:inputFileName = $null
[String]$script:inputFileExt = $null
[Xml]$script:csProjFile = $null

function PrintHeader
{
    if ($Silent) { return }

    "-"*80
    "  .NET 5 C# Project File Version and Assembly Information Updater"
    "  Zach `"KhaosVoid`" Tommey 2021"
    "-"*80
    "  Running with the following arguments:`n"
    "    CSProjPath: $CSProjPath"

    if ($Authors) { "    Authors: $Authors" }
    if ($Company) { "    Company: $Company" }
    if ($Product) { "    Product: $Product" }
    if ($Description) { "    Description: $Description" }
    if ($Copyright) { "    Copyright: $Copyright" }
    if ($AppendCopyrightYear) { "    AppendCopyrightYear: $AppendCopyrightYear" }

    "-"*80
}

function LoadInputFile
{
    $script:inputFilePath = Resolve-Path $CSProjPath
    $script:inputFileName = [System.IO.Path]::GetFileName("$script:inputFilePath")
    $script:inputFileExt = [System.IO.Path]::GetExtension("$script:inputFilePath").ToLowerInvariant()

    if ($script:inputFileExt -ne ".csproj")
    {
        Write-Error "Input file is not of type `".csproj`"."
        exit
    }

    [Xml]$script:csProjFile = Get-Content "$script:inputFilePath"

    if ($Silent -eq $false) { "Loaded `"$script:inputFilePath`"." }
}

function DetermineAction
{
    if ($GetAuthors) { GetAuthors }
    elseif ($GetCompany) { GetCompany }
    elseif ($GetProduct) { GetProduct }
    elseif ($GetDescription) { GetDescription }
    elseif ($GetCopyright) { GetCopyright }
    elseif ($GetVersion) { [String]$vStr = GetVersion; $vStr }
    else { SetAssemblyInfo }
}

function GetAuthors
{
    return [String]$script:csProjFile.Project.PropertyGroup.Authors
}

function GetCompany
{
    return [String]$script:csProjFile.Project.PropertyGroup.Company
}

function GetProduct
{
    return [String]$script:csProjFile.Project.PropertyGroup.Product
}

function GetDescription
{
    return [String]$script:csProjFile.Project.PropertyGroup.Description
}

function GetCopyright
{
    return [String]$script:csProjFile.Project.PropertyGroup.Copyright
}

function GetVersion
{
    $version = $script:csProjFile.Project.PropertyGroup.AssemblyVersion
    $varVersionIsNullOrEmpty = $version -eq $null -or $version -eq ""

    if ($varVersionIsNullOrEmpty)
    {
        if ($GetVersion -and $Silent -eq $false)
        {
            Write-Warning "`"AssemblyVersion`" was not found in PropertyGroup for Project. Returning default version."
        }

        [Version]$version = CreateVersion
    }

    return [Version]$version
}

function CreateVersion
{
    param(
        [Int]$major = 0,
        [Int]$minor = 0,
        [Int]$build = 0,
        [Int]$revision = 0
    )

    return New-Object -TypeName:Version -ArgumentList:"$major.$minor.$build.$revision"
}

function SetAssemblyInfo
{
    if ($Silent -eq $false) { "Updating assembly and version information..." }

    [Int]$varYear = Get-Date -UFormat:"%Y"
    [Int]$varMonth = Get-Date -UFormat:"%m"
    [Int]$varDay = Get-Date -UFormat:"%d"
    [String]$varCopyrightStr = $Copyright
    [Version]$varPreviousVersion = GetVersion
    [Version]$varNextVersion = $null;

    if ($Copyright -and $AppendCopyrightYear)
    {
        $varCopyrightStr += " $varYear"
    }

    if ($varYear -eq $varPreviousVersion.Major -and
        $varMonth -eq $varPreviousVersion.Minor -and
        $varDay -eq $varPreviousVersion.Build)
    {
        [Int]$varNextRevision = $varPreviousVersion.Revision + 1
        $varNextVersion = CreateVersion -major:$varYear -minor:$varMonth -build:$varDay -revision:$varNextRevision

        if ($Silent -eq $false)
        {
            "Incrementing version from [" + [String]$varPreviousVersion + "] to [" + [String]$varNextVersion + "].`n"
        }
    }

    else
    {
        $varNextVersion = CreateVersion -major:$varYear -minor:$varMonth -build:$varDay -revision:0

        if ($Silent -eq $false)
        {
            "Set version to [" + [String]$varNextVersion + "].`n"
        }
    }


    if ($Authors) { TrySetPropertyGroupEntry -name:"Authors" -value:$Authors }
    if ($Company) { TrySetPropertyGroupEntry -name:"Company" -value:$Company }
    if ($Product) { TrySetPropertyGroupEntry -name:"Product" -value:$Product }
    if ($Description) { TrySetPropertyGroupEntry -name:"Description" -value:$Description }
    if ($Copyright) { TrySetPropertyGroupEntry -name:"Copyright" -value:$varCopyrightStr }
    
    TrySetPropertyGroupEntry -name:"Version" -value:$varNextVersion
    TrySetPropertyGroupEntry -name:"AssemblyVersion" -value:$varNextVersion
    TrySetPropertyGroupEntry -name:"FileVersion" -value:$varNextVersion

    $script:csProjFile.Save($script:inputFilePath)

    if ($Silent -eq $false)
    {
        "`nSaved assembly and version information!`n"
        "-"*80
    }
}

function TrySetPropertyGroupEntry
{
    param(
        [Parameter(Mandatory)]
        [String]$name,

        [Parameter(Mandatory)]
        [String]$value
    )

    [System.Xml.XmlElement]$element = $script:csProjFile.Project.PropertyGroup.SelectSingleNode($name)

    if ($element -eq $null)
    {
        if ($Silent -eq $false)
        {
            Write-Warning "`"$name`" was not found in PropertyGroup for Project. Appending new element."
        }

        [System.Xml.XmlElement]$element = CreatePropertyGroupEntry -name:$name
    }

    $element.InnerText = $value
}

function CreatePropertyGroupEntry
{
    param(
        [Parameter(Mandatory)]
        [String]$name
    )

    $newElement = $script:csProjFile.CreateElement("$name")
    return $script:csProjFile.Project.PropertyGroup.AppendChild($newElement)
}

PrintHeader
LoadInputFile
DetermineAction