using BMSSV.IO.MetroidDread;
using BMSSV.IO.MetroidDread.Properties;
using Excalibur.Wpf.Core.DataModels;
using Excalibur.Wpf.Core.DataModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDSaveEditor.DataModels
{
    public class PlayerInventoryModel : EditableDataModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty SuitsInventoryProperty;
        public static readonly DependencyProperty BeamsInventoryProperty;
        public static readonly DependencyProperty MissilesInventoryProperty;
        public static readonly DependencyProperty AbilitiesInventoryProperty;
        public static readonly DependencyProperty MorphBallAbilitiesInventoryProperty;
        public static readonly DependencyProperty AeionAbilitiesInventoryProperty;
        public static readonly DependencyProperty ConsumablesInventoryProperty;
        public static readonly DependencyProperty CollectablesInventoryProperty;

        public static readonly DependencyProperty MetroidnizationProperty;
        public static readonly DependencyProperty MetroidTotalCountProperty;
        public static readonly DependencyProperty MetroidCountProperty;

        #endregion Dependency Properties

        #region Properties

        public SuitsInventoryModel SuitsInventory
        {
            get => (SuitsInventoryModel)GetValue(SuitsInventoryProperty);
            set => SetValue(SuitsInventoryProperty, value);
        }

        public BeamsInventoryModel BeamsInventory
        {
            get => (BeamsInventoryModel)GetValue(BeamsInventoryProperty);
            set => SetValue(BeamsInventoryProperty, value);
        }

        public MissilesInventoryModel MissilesInventory
        {
            get => (MissilesInventoryModel)GetValue(MissilesInventoryProperty);
            set => SetValue(MissilesInventoryProperty, value);
        }

        public AbilitiesInventoryModel AbilitiesInventory
        {
            get => (AbilitiesInventoryModel)GetValue(AbilitiesInventoryProperty);
            set => SetValue(AbilitiesInventoryProperty, value);
        }

        public MorphBallAbilitiesInventoryModel MorphBallAbilitiesInventory
        {
            get => (MorphBallAbilitiesInventoryModel)GetValue(MorphBallAbilitiesInventoryProperty);
            set => SetValue(MorphBallAbilitiesInventoryProperty, value);
        }

        public AeionAbilitiesInventoryModel AeionAbilitiesInventory
        {
            get => (AeionAbilitiesInventoryModel)GetValue(AeionAbilitiesInventoryProperty);
            set => SetValue(AeionAbilitiesInventoryProperty, value);
        }

        public ConsumablesInventoryModel ConsumablesInventory
        {
            get => (ConsumablesInventoryModel)GetValue(ConsumablesInventoryProperty);
            set => SetValue(ConsumablesInventoryProperty, value);
        }

        public CollectablesInventoryModel CollectablesInventory
        {
            get => (CollectablesInventoryModel)GetValue(CollectablesInventoryProperty);
            set => SetValue(CollectablesInventoryProperty, value);
        }

        public bool Metroidnization
        {
            get => (bool)GetValue(MetroidnizationProperty);
            set => SetValue(MetroidnizationProperty, value);
        }

        public int MetroidTotalCount
        {
            get => (int)GetValue(MetroidTotalCountProperty);
            set => SetValue(MetroidTotalCountProperty, value);
        }
        public int MetroidCount
        {
            get => (int)GetValue(MetroidCountProperty);
            set => SetValue(MetroidCountProperty, value);
        }

        #endregion Properties

        #region Ctor

        static PlayerInventoryModel()
        {
            SuitsInventoryProperty = RegisterTracked("SuitsInventory", typeof(SuitsInventoryModel), typeof(PlayerInventoryModel));
            BeamsInventoryProperty = RegisterTracked("BeamsInventory", typeof(BeamsInventoryModel), typeof(PlayerInventoryModel));
            MissilesInventoryProperty = RegisterTracked("MissilesInventory", typeof(MissilesInventoryModel), typeof(PlayerInventoryModel));
            AbilitiesInventoryProperty = RegisterTracked("AbilitiesInventory", typeof(AbilitiesInventoryModel), typeof(PlayerInventoryModel));
            MorphBallAbilitiesInventoryProperty = RegisterTracked("MorphBallAbilitiesInventory", typeof(MorphBallAbilitiesInventoryModel), typeof(PlayerInventoryModel));
            AeionAbilitiesInventoryProperty = RegisterTracked("AeionAbilitiesInventory", typeof(AeionAbilitiesInventoryModel), typeof(PlayerInventoryModel));
            ConsumablesInventoryProperty = RegisterTracked("ConsumablesInventory", typeof(ConsumablesInventoryModel), typeof(PlayerInventoryModel));
            CollectablesInventoryProperty = RegisterTracked("CollectablesInventory", typeof(CollectablesInventoryModel), typeof(PlayerInventoryModel));
            MetroidnizationProperty = RegisterTracked("Metroidnization", typeof(bool), typeof(PlayerInventoryModel));
            MetroidTotalCountProperty = RegisterTracked("MetroidTotalCount", typeof(int),  typeof(PlayerInventoryModel));
            MetroidCountProperty = RegisterTracked("MetroidCount", typeof(int),  typeof(PlayerInventoryModel));
        }

        public PlayerInventoryModel()
        {
            SuitsInventory = new SuitsInventoryModel();
            BeamsInventory = new BeamsInventoryModel();
            MissilesInventory = new MissilesInventoryModel();
            AbilitiesInventory = new AbilitiesInventoryModel();
            MorphBallAbilitiesInventory = new MorphBallAbilitiesInventoryModel();
            AeionAbilitiesInventory = new AeionAbilitiesInventoryModel();
            ConsumablesInventory = new ConsumablesInventoryModel();
            CollectablesInventory = new CollectablesInventoryModel();
        }

        #endregion Ctor

        #region Methods

        public static PlayerInventoryModel FromBMSSVSection(Section section)
        {
            if (section.Name != "PLAYER_INVENTORY")
            {
                throw new ArgumentException(
                    message: "Invalid section. Parameter must be a valid PLAYER_INVENTORY section.",
                    paramName: nameof(section));
            }

            return new PlayerInventoryModel()
            {
                SuitsInventory = new SuitsInventoryModel()
                {
                    VariaSuit = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_VARIA_SUIT")?.Value),
                    GravitySuit = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_GRAVITY_SUIT")?.Value),
                    MetroidSuit = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_HYPER_SUIT")?.Value)
                }.Initialize(),
                BeamsInventory = new BeamsInventoryModel()
                {
                    WideBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_WIDE_BEAM")?.Value),
                    PlasmaBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_PLASMA_BEAM")?.Value),
                    WaveBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_WAVE_BEAM")?.Value),
                    HyperBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_HYPER_BEAM")?.Value),
                    ChargeBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_CHARGE_BEAM")?.Value),
                    DiffusionBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_DIFFUSION_BEAM")?.Value),
                    GrappleBeam = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_GRAPPLE_BEAM")?.Value),
                    OmegaCannon = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_CENTRAL_UNIT_ENERGY")?.Value),
                    IsOmegaStreamDisabled = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_CENTRAL_UNIT_DECAYED_ENERGY")?.Value)
                }.Initialize(),
                MissilesInventory = new MissilesInventoryModel()
                {
                    SuperMissile = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_SUPER_MISSILE")?.Value),
                    IceMissile = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_ICE_MISSILE")?.Value),
                    StormMissiles = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_MULTILOCKON")?.Value)
                }.Initialize(),
                AbilitiesInventory = new AbilitiesInventoryModel()
                {
                    FloorSlide = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_FLOOR_SLIDE")?.Value),
                    SpiderMagnet = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_MAGNET_GLOVE")?.Value),
                    SpeedBooster = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_SPEED_BOOSTER")?.Value),
                    SpinBoost = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_DOUBLE_JUMP")?.Value),
                    SpaceJump = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_SPACE_JUMP")?.Value),
                    ScrewAttack = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_SCREW_ATTACK")?.Value)
                }.Initialize(),
                MorphBallAbilitiesInventory = new MorphBallAbilitiesInventoryModel()
                {
                    MorphBall = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_MORPH_BALL")?.Value),
                    MorphBallBomb = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_BOMB")?.Value),
                    MorphBallLineBomb = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_LINE_BOMB")?.Value),
                    PowerBomb = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_POWER_BOMB")?.Value)
                }.Initialize(),
                AeionAbilitiesInventory = new AeionAbilitiesInventoryModel()
                {
                    PhantomCloak = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_OPTIC_CAMOUFLAGE")?.Value),
                    FlashShift = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_GHOST_AURA")?.Value),
                    PulseRadar = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_SONAR")?.Value)
                }.Initialize(),
                ConsumablesInventory = new ConsumablesInventoryModel()
                {
                    MaxEnergy = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_MAX_LIFE")?.Value),
                    CurrentEnergy = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_CURRENT_LIFE")?.Value),
                    LifeShards = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_LIFE_SHARDS")?.Value),
                    EnergyTankShards = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_ENERGY_TANK_SHARDS")?.Value),
                    MaxAeionEnergy = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_MAX_SPECIAL_ENERGY")?.Value),
                    CurrentAeionEnergy = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_CURRENT_SPECIAL_ENERGY")?.Value),
                    MaxMissiles = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_MISSILE_MAX")?.Value),
                    CurrentMissiles = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_MISSILE_CURRENT")?.Value),
                    MaxPowerBombs = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_POWER_BOMB_MAX")?.Value),
                    CurrentPowerBombs = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_WEAPON_POWER_BOMB_CURRENT")?.Value)
                }.Initialize(),
                CollectablesInventory = new CollectablesInventoryModel()
                {
                    TotalLifeShards = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_TOTAL_LIFE_SHARDS")?.Value),
                    EnergyTanks = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_ENERGY_TANKS")?.Value),
                    MissileTanks = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_MISSILE_TANKS")?.Value),
                    MissilePlusTanks = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_MISSILE_PLUS_TANKS")?.Value),
                    PowerBombTanks = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_POWER_BOMB_TANKS")?.Value)
                }.Initialize(),

                Metroidnization = Convert.ToBoolean(section.TryGetProperty<FloatProperty>("ITEM_METROIDNIZATION")?.Value),
                MetroidTotalCount = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_METROID_TOTAL_COUNT")?.Value),
                MetroidCount = Convert.ToInt32(section.TryGetProperty<FloatProperty>("ITEM_METROID_COUNT")?.Value)
            }.Initialize();
        }

        public static Section ToSection(PlayerInventoryModel model)
        {
            return new Section("PLAYER_INVENTORY")
            {
                Properties = new Dictionary<string, IProperty>()
                {
                    { "ITEM_VARIA_SUIT", new FloatProperty("ITEM_VARIA_SUIT", Convert.ToSingle(model.SuitsInventory.VariaSuit)) },
                    { "ITEM_GRAVITY_SUIT", new FloatProperty("ITEM_GRAVITY_SUIT", Convert.ToSingle(model.SuitsInventory.GravitySuit)) },
                    { "ITEM_HYPER_SUIT", new FloatProperty("ITEM_HYPER_SUIT", Convert.ToSingle(model.SuitsInventory.MetroidSuit)) },
                    { "ITEM_WEAPON_WIDE_BEAM", new FloatProperty("ITEM_WEAPON_WIDE_BEAM", Convert.ToSingle(model.BeamsInventory.WideBeam)) },
                    { "ITEM_WEAPON_PLASMA_BEAM", new FloatProperty("ITEM_WEAPON_PLASMA_BEAM", Convert.ToSingle(model.BeamsInventory.PlasmaBeam)) },
                    { "ITEM_WEAPON_WAVE_BEAM", new FloatProperty("ITEM_WEAPON_WAVE_BEAM", Convert.ToSingle(model.BeamsInventory.WaveBeam)) },
                    { "ITEM_WEAPON_HYPER_BEAM", new FloatProperty("ITEM_WEAPON_HYPER_BEAM", Convert.ToSingle(model.BeamsInventory.HyperBeam)) },
                    { "ITEM_WEAPON_CHARGE_BEAM", new FloatProperty("ITEM_WEAPON_CHARGE_BEAM", Convert.ToSingle(model.BeamsInventory.ChargeBeam)) },
                    { "ITEM_WEAPON_DIFFUSION_BEAM", new FloatProperty("ITEM_WEAPON_DIFFUSION_BEAM", Convert.ToSingle(model.BeamsInventory.DiffusionBeam)) },
                    { "ITEM_WEAPON_GRAPPLE_BEAM", new FloatProperty("ITEM_WEAPON_GRAPPLE_BEAM", Convert.ToSingle(model.BeamsInventory.GrappleBeam)) },
                    { "ITEM_CENTRAL_UNIT_ENERGY", new FloatProperty("ITEM_CENTRAL_UNIT_ENERGY", Convert.ToSingle(model.BeamsInventory.OmegaCannon)) },
                    { "ITEM_CENTRAL_UNIT_DECAYED_ENERGY", new FloatProperty("ITEM_CENTRAL_UNIT_DECAYED_ENERGY", Convert.ToSingle(model.BeamsInventory.IsOmegaStreamDisabled)) },
                    { "ITEM_WEAPON_SUPER_MISSILE", new FloatProperty("ITEM_WEAPON_SUPER_MISSILE", Convert.ToSingle(model.MissilesInventory.SuperMissile)) },
                    { "ITEM_WEAPON_ICE_MISSILE", new FloatProperty("ITEM_WEAPON_ICE_MISSILE", Convert.ToSingle(model.MissilesInventory.IceMissile)) },
                    { "ITEM_MULTILOCKON", new FloatProperty("ITEM_MULTILOCKON", Convert.ToSingle(model.MissilesInventory.StormMissiles)) },
                    { "ITEM_FLOOR_SLIDE", new FloatProperty("ITEM_FLOOR_SLIDE", Convert.ToSingle(model.AbilitiesInventory.FloorSlide)) },
                    { "ITEM_MAGNET_GLOVE", new FloatProperty("ITEM_MAGNET_GLOVE", Convert.ToSingle(model.AbilitiesInventory.SpiderMagnet)) },
                    { "ITEM_SPEED_BOOSTER", new FloatProperty("ITEM_SPEED_BOOSTER", Convert.ToSingle(model.AbilitiesInventory.SpeedBooster)) },
                    { "ITEM_DOUBLE_JUMP", new FloatProperty("ITEM_DOUBLE_JUMP", Convert.ToSingle(model.AbilitiesInventory.SpinBoost)) },
                    { "ITEM_SPACE_JUMP", new FloatProperty("ITEM_SPACE_JUMP", Convert.ToSingle(model.AbilitiesInventory.SpaceJump)) },
                    { "ITEM_SCREW_ATTACK", new FloatProperty("ITEM_SCREW_ATTACK", Convert.ToSingle(model.AbilitiesInventory.ScrewAttack)) },
                    { "ITEM_MORPH_BALL", new FloatProperty("ITEM_MORPH_BALL", Convert.ToSingle(model.MorphBallAbilitiesInventory.MorphBall)) },
                    { "ITEM_WEAPON_BOMB", new FloatProperty("ITEM_WEAPON_BOMB", Convert.ToSingle(model.MorphBallAbilitiesInventory.MorphBallBomb)) },
                    { "ITEM_WEAPON_LINE_BOMB", new FloatProperty("ITEM_WEAPON_LINE_BOMB", Convert.ToSingle(model.MorphBallAbilitiesInventory.MorphBallLineBomb)) },
                    { "ITEM_WEAPON_POWER_BOMB", new FloatProperty("ITEM_WEAPON_POWER_BOMB", Convert.ToSingle(model.MorphBallAbilitiesInventory.PowerBomb)) },
                    { "ITEM_OPTIC_CAMOUFLAGE", new FloatProperty("ITEM_OPTIC_CAMOUFLAGE", Convert.ToSingle(model.AeionAbilitiesInventory.PhantomCloak)) },
                    { "ITEM_GHOST_AURA", new FloatProperty("ITEM_GHOST_AURA", Convert.ToSingle(model.AeionAbilitiesInventory.FlashShift)) },
                    { "ITEM_SONAR", new FloatProperty("ITEM_SONAR", Convert.ToSingle(model.AeionAbilitiesInventory.PulseRadar)) },
                    { "ITEM_MAX_LIFE", new FloatProperty("ITEM_MAX_LIFE", model.ConsumablesInventory.MaxEnergy) },
                    { "ITEM_CURRENT_LIFE", new FloatProperty("ITEM_CURRENT_LIFE", model.ConsumablesInventory.CurrentEnergy) },
                    { "ITEM_LIFE_SHARDS", new FloatProperty("ITEM_LIFE_SHARDS", model.ConsumablesInventory.LifeShards) },
                    { "ITEM_ENERGY_TANK_SHARDS", new FloatProperty("ITEM_ENERGY_TANK_SHARDS", model.ConsumablesInventory.EnergyTankShards) },
                    { "ITEM_MAX_SPECIAL_ENERGY", new FloatProperty("ITEM_MAX_SPECIAL_ENERGY", model.ConsumablesInventory.MaxAeionEnergy) },
                    { "ITEM_CURRENT_SPECIAL_ENERGY", new FloatProperty("ITEM_CURRENT_SPECIAL_ENERGY", model.ConsumablesInventory.CurrentAeionEnergy) },
                    { "ITEM_WEAPON_MISSILE_MAX", new FloatProperty("ITEM_WEAPON_MISSILE_MAX", model.ConsumablesInventory.MaxMissiles) },
                    { "ITEM_WEAPON_MISSILE_CURRENT", new FloatProperty("ITEM_WEAPON_MISSILE_CURRENT", model.ConsumablesInventory.CurrentMissiles) },
                    { "ITEM_WEAPON_POWER_BOMB_MAX", new FloatProperty("ITEM_WEAPON_POWER_BOMB_MAX", model.ConsumablesInventory.MaxPowerBombs) },
                    { "ITEM_WEAPON_POWER_BOMB_CURRENT", new FloatProperty("ITEM_WEAPON_POWER_BOMB_CURRENT", model.ConsumablesInventory.CurrentPowerBombs) },
                    { "ITEM_TOTAL_LIFE_SHARDS", new FloatProperty("ITEM_TOTAL_LIFE_SHARDS", model.CollectablesInventory.TotalLifeShards) },
                    { "ITEM_ENERGY_TANKS", new FloatProperty("ITEM_ENERGY_TANKS", model.CollectablesInventory.EnergyTanks) },
                    { "ITEM_MISSILE_TANKS", new FloatProperty("ITEM_MISSILE_TANKS", model.CollectablesInventory.MissileTanks) },
                    { "ITEM_MISSILE_PLUS_TANKS", new FloatProperty("ITEM_MISSILE_PLUS_TANKS", model.CollectablesInventory.MissilePlusTanks) },
                    { "ITEM_POWER_BOMB_TANKS", new FloatProperty("ITEM_POWER_BOMB_TANKS", model.CollectablesInventory.PowerBombTanks) },
                    { "ITEM_METROIDNIZATION", new FloatProperty("ITEM_METROIDNIZATION", Convert.ToSingle(model.Metroidnization)) },
                    { "ITEM_METROID_TOTAL_COUNT", new FloatProperty("ITEM_METROID_TOTAL_COUNT", model.MetroidTotalCount) },
                    { "ITEM_METROID_COUNT", new FloatProperty("ITEM_METROID_COUNT", model.MetroidCount) }
                }
            };
        }

        #endregion Methods
    }
}
