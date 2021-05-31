using System;
using System.ComponentModel;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader.Config;
using ModLibsTiles.Classes.Tiles.TilePattern;


namespace TerrainRemixer {
	public enum FractalType {
		FBM = 0,
		Billow = 1,
		RigidMulti = 2
	}




	public partial class TerrainRemixerGenPassSpec {
		public TilePatternConfig Filter { get; set; } = new TilePatternConfig(
			new TilePatternBuilder { IsActive = true }
		);


		////

		[Tooltip( "A \"scale\" value given to the noise algorithm. \nSmaller = more dramatic." )]
		[Range( 0.0001f, 0.3f )]
		[DefaultValue( 0.01f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseFrequency { get; set; } = 0.01f;

		[Tooltip( "Picks between fractal modes that can make the generation more worm-like." )]
		[DefaultValue( FractalType.FBM )]
		public FractalType WormsMode { get; set; } = FractalType.FBM;

		[Tooltip( "A \"sharpness\" value given to the noise algorithm. \nSmaller = more blurry." )]
		[Range( 0f, 5f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float Sharpness { get; set; } = 0.5f;

		//[Tooltip( "Applies 'gradient perturb' to make a more wavy result." )]
		//[DefaultValue( false )]
		//public bool IsPerturbed { get; set; } = false;


		////

		[Tooltip( "Minimum value range of noise ouput per tile before it is removed. \nSmaller = thicker terrain." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseValueMinimumUntilTileRemoval { get; set; } = 0.5f;


		////

		[Tooltip( "Percent of vertical distance from region's center before blending starts." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.7f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float VerticalDistancePercentFromCenterBeforeBlending { get; set; } = 0.7f;

		[Tooltip( "Percent of horizontal distance from region's center before blending starts." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.7f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float HorizontalDistancePercentFromCenterBeforeBlending { get; set; } = 0.7f;

		////

		[Tooltip( "A selection of tile types to randomly pick from when painting noise. `-1` is air." )]
		public List<int> FillTiles { get; set; } = new List<int> { -1 };

		[Tooltip( "A selection of wall types to randomly pick from when painting noise." )]
		public List<int> FillWalls { get; set; } = new List<int> { };



		////////////////

		/*public override bool Equals( object obj ) {
			return base.Equals( obj );
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}*/
	}
}
