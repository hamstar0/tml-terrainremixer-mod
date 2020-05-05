﻿using System;
using System.ComponentModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Terraria;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.Tiles.TilePattern;
using HamstarHelpers.Helpers.World;


namespace TerrainRemixer {
	public enum WorldDepth {
		Sky,
		Surface,
		UgDirt,
		UgRock,
		Underworld,
		Bottom
	}




	public partial class TerrainRemixerGenPassSpec {
		public static int GetDepthTile( WorldDepth depth ) {
			switch( depth ) {
			case WorldDepth.Sky:
				return 0;
			case WorldDepth.Surface:
				return WorldHelpers.SurfaceLayerTopTileY;
			case WorldDepth.UgDirt:
				return WorldHelpers.DirtLayerTopTileY;
			case WorldDepth.UgRock:
				return WorldHelpers.RockLayerTopTileY;
			case WorldDepth.Underworld:
				return WorldHelpers.UnderworldLayerTopTileY;
			case WorldDepth.Bottom:
				return Main.maxTilesY - 1;
			default:
				return -1;
			}
		}



		////////////////

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int DepthOffsetTop { get; set; } = 0;

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int DepthOffsetBottom { get; set; } = 0;

		[JsonConverter( typeof( StringEnumConverter ) )]
		[DefaultValue( WorldDepth.Sky )]
		public WorldDepth DepthStartBase { get; set; } = WorldDepth.Sky;

		[JsonConverter( typeof( StringEnumConverter ) )]
		[DefaultValue( WorldDepth.UgDirt )]
		public WorldDepth DepthEndBase { get; set; } = WorldDepth.UgDirt;
	}
}
