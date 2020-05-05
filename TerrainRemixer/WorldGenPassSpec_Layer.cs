using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace TerrainRemixer {
	public partial class TerrainRemixerGenPassSpec {
		[DefaultValue( true )]
		public bool IsAfter { get; set; } = true;

		//[JsonConverter( typeof( StringEnumConverter ) )]
		[DrawTicks]
		[OptionStrings( new string[] {
			"Reset",
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
			"Final Cleanup" } )]
		[DefaultValue( "Terrain" )]
		public string LayerName { get; set; }

		////

		//[DefaultValue( false )]
		//public bool ReplacesLayer { get; set; } = false;
	}
}
