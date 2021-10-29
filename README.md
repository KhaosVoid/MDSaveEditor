# Metroid Dread Save Editor
This project is for the development of the save editor for Metroid Dread. The project is still in it's early stages, but currently, editing of the `PLAYER_INVENTORY` section in common.bmssv will allow for changing various equipment information, such as Missiles, Beams, Suits, Abilities, and Min/Max Energy, Missiles, and Power Bombs.

More is planned for this editor once my development of the IO library gets further along.

To download the latest version, please visit the [Releases](https://github.com/KhaosVoid/MDSaveEditor/releases) page.

<br />

## Dependencies
This project is developed using .NET 5.0 and WPF for the UI. There are two NuGet dependencies:

### [BMSSV.IO](https://github.com/KhaosVoid/BMSSV.IO)
This is the IO library that allows reading/writting of the BMSSV format. Still in active development.

### Excalibur
This is the UI library that I developed to augment MVVM development in WPF. Source is currently closed to the public, but will be opened at a later time.

<br />

## Contributing
This is an independently developed project. Currently, pull requests will not be accepted as this project will be changing constantly as I get further along with the development of the IO library.
