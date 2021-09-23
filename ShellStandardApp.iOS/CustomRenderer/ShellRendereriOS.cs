using System;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using ShellStandardApp.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamSvg.XamForms;

[assembly: ExportRenderer(typeof(Shell), typeof(ShellRendereriOS))]
namespace ShellStandardApp.iOS.CustomRenderer
{
	public class ShellRendereriOS : ShellRenderer
	{
		//protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
		//{
		//    var shellSectionRenderer = new CustomShellSectionRenderer(this);
		//    return shellSectionRenderer;
		//}

		/// <summary>
		/// The CreateShellItemRenderer.
		/// </summary>
		/// <param name="item">The item<see cref="ShellItem"/>.</param>
		/// <returns>The <see cref="IShellItemRenderer"/>.</returns>
		//protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
		//{
		//	var renderer = new ShellTabItemRenderer(this) { ShellItem = item };

		//	renderer.View.BackgroundColor = Color.Yellow.ToUIColor();

		//	return renderer;
		//}

		protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
		{
			return new CustomTabBarAppearanceTracker();
		}

	}

	public class CustomTabBarAppearanceTracker : ShellTabBarAppearanceTracker
	{
		//public override void ResetAppearance(UITabBarController controller)
		//{
		//	if (controller.TabBar.Items != null)
		//	{
		//		foreach (UITabBarItem tabbaritem in controller.TabBar.Items)
		//		{
		//			tabbaritem.Image = tabbaritem.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		//			tabbaritem.SelectedImage = tabbaritem.SelectedImage?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
		//		}
		//	}
		//}

		public override async void SetAppearance(UITabBarController controller, ShellAppearance appearance)
		{
			//controller.TabBar.SelectedImageTintColor = Color.Black.ToUIColor();
			//controller.TabBar.UnselectedItemTintColor = Color.Black.ToUIColor();
			//controller.TabBar.BarTintColor = Color.Red.ToUIColor();

			if (controller.TabBar.Items != null)
			{
				foreach (UITabBarItem tabbaritem in controller.TabBar.Items)
				{
					//SvgImageSource svgImageSource = SvgImageSource.FromResource("ShellStandardApp.SVGResource.appleicon.svg");
					//UIImage uiImageView = await ImageService.Instance.LoadEmbeddedResource("resource://appleicon.svg").WithCustomDataResolver(new SvgDataResolver(64, 0, true)).AsUIImageAsync();

					//var svgImageSource = SvgImageSource.FromResource("resource://ShellStandardApp.SVGResource.appleicon.svg");
					//var uiImageView = await GetUIImageFromImageSourceAsync(svgImageSource);

					UIImage uiImage = await ImageService.Instance.LoadFile("appleicon.svg")
					.WithCustomDataResolver(new SvgDataResolver(15, 15, true))
					.AsUIImageAsync();

					// TODO: No SVG image wil be displayed because uiImageView in NULL
					tabbaritem.Image = uiImage;


					tabbaritem.Image = tabbaritem.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
					tabbaritem.SelectedImage = tabbaritem.SelectedImage?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
				}
			}
		}

		public static async Task<UIImage> GetUIImageFromImageSourceAsync(ImageSource source)
		{
			var handler = GetHandler(source);
			var returnValue = (UIImage)null;

			returnValue = await handler.LoadImageAsync(source);

			return returnValue;
		}

		private static IImageSourceHandler GetHandler(ImageSource source)
		{
			IImageSourceHandler returnValue = null;
			if (source is UriImageSource)
			{
				returnValue = new ImageLoaderSourceHandler();
			}
			else if (source is FileImageSource)
			{
				returnValue = new FileImageSourceHandler();
			}
			else if (source is StreamImageSource)
			{
				returnValue = new StreamImagesourceHandler();
			}
			return returnValue;
		}
	}
}