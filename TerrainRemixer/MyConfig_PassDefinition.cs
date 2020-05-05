using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.Tiles.TilePattern;


namespace TerrainRemixer {
	public class TerrainRemixerPassDefinition {
		[DefaultValue( true )]
		public bool IsAfter { get; set; } = true;

		//[JsonConverter( typeof( StringEnumConverter ) )]
		[DrawTicks]
		[OptionStrings( new string[] {
			"Terrain",
			"Tunnels",
			"Sand",
			"Mount Caves",
			"Dirt Wall Backgrounds",
			"Rocks In Dirt",
			"Dirt In Rocks",
			"Clay",
			"Small Holes",
			"Dirt Layer Caves",
			"Rock Layer Caves",
			"Surface Caves",
			"Slush Check",
			"Grass",
			"Jungle",
			"Marble",
			"Granite",
			"Mud Caves To Grass",
			"Full Desert",
			"Floating Islands",
			"Mushroom Patches",
			"Mud To Dirt",
			"Silt",
			"Shinies",
			"Webs",
			"Underworld",
			"Lakes",
			"Dungeon",
			"Corruption",
			"Slush",
			"Mud Caves To Grass",
			"Beaches",
			"Gems",
			"Gravitating Sand",
			"Clean Up Dirt",
			"Pyramids",
			"Dirt Rock Wall Runner",
			"Living Trees",
			"Wood Tree Walls",
			"Altars",
			"Wet Jungle",
			"Jungle Temple",
			"Hives",
			"Jungle Chests",
			"Smooth World",
			"Settle Liquids",
			"Waterfalls",
			"Ice",
			"Wall Variety",
			"Traps",
			"Life Crystals",
			"Statues",
			"Buried Chests",
			"Surface Chests",
			"Jungle Chests Placement",
			"Water Chests",
			"Spider Caves",
			"Gem Caves",
			"Moss",
			"Temple",
			"Ice Walls",
			"Jungle Trees",
			"Floating Island Houses",
			"Quick Cleanup",
			"Quick Cleanup",
			"Pots",
			"Hellforge",
			"Spreading Grass",
			"Piles",
			"Moss",
			"Spawn Point",
			"Grass Wall",
			"Guide",
			"Sunflowers",
			"Planting Trees",
			"Herbs",
			"Dye Plants",
			"Webs And Honey",
			"Weeds",
			"Mud Caves To Grass",
			"Jungle Plants",
			"Vines",
			"Flowers",
			"Mushrooms",
			"Stalac",
			"Gems In Ice Biome",
			"Random Gems",
			"Moss Grass",
			"Muds Walls In Jungle",
			"Larva",
			"Settle Liquids Again",
			"Tile Cleanup",
			"Lihzahrd Altars",
			"Micro Biomes",
			"Final Cleanup",
		} )]
		[DefaultValue( "Terrain" )]
		public string LayerName { get; set; }

		////

		[DefaultValue( false )]
		public bool ReplacesLayer { get; set; } = false;

		////

		public TilePatternConfig Filter { get; set; }

		[Range( 0.001f, 1f )]
		[DefaultValue( 0.05f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float Scale { get; set; }


		////////////////

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int MaxDepthOffset { get; set; } = 0;

		[DefaultValue( true )]
		public bool IsMaxDepthSurfaceBottom { get; set; } = true;

		[DefaultValue( false )]
		public bool IsMaxDepthDirtLayerBottom { get; set; } = false;

		[DefaultValue( false )]
		public bool IsMaxDepthRockLayerBottom { get; set; } = false;

		[Range( 0f, 1f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float BaseNoisePercentThresholdMinimumForSolid { get; set; } = 0.5f;

		[Range( 0f, 1f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float BaseNoisePercentThresholdMinimumForWall { get; set; } = 0.5f;

		[DefaultValue( true )]
		public bool FadesToBottom { get; set; } = true;



		////////////////

		public override bool Equals( object obj ) {
			return base.Equals( obj );
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}
	}
}
