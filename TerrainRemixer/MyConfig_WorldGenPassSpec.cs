using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.Tiles.TilePattern;


namespace TerrainRemixer {
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

		[Tooltip( "Switches to a fractal mode that makes the generation more worm-like." )]
		[DefaultValue( false )]
		public bool IsWorms { get; set; } = false;

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



		////////////////

		/*public override bool Equals( object obj ) {
			return base.Equals( obj );
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}*/
	}
}
