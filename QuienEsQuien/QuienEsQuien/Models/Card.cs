

using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuienEsQuien.Models
{
    public class Card : ContentView
    {
        Image img;
        Frame frame;

        public int Index { private set; get; }
        public int Row { set; get; }
        public int Col { set; get; }

        public Card(int index)
        {
            Index = index;

            img = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromResource(string.Format("QuienEsQuien.img.{0}.png", index + 1))
            };

            frame = new Frame
            {
                BackgroundColor = Color.White,
                OutlineColor = Color.Accent,
                Padding = new Thickness(5, 10, 5, 0),
                Content = new StackLayout
                {

                    Spacing = 0,
                    Children = 
                        {
                            img,
                        }
                }
            };
            this.Content = frame;
            this.BackgroundColor = Color.Transparent;
        }

        public async Task AnimateSelectAsync()
        {
            uint length = 150;
            await Task.WhenAll(this.ScaleTo(-1, length));
            await Task.WhenAll(CardDown());
            await Task.WhenAll(this.ScaleTo(1, length));
            this.Rotation = 0;
        }
        public async Task AnimateWinAsync()
        {
            uint length = 150;
            await Task.WhenAll(this.ScaleTo(1, length), this.RotateTo(180, length),this.TranslateTo(0,-300,length));
            await Task.WhenAll(this.ScaleTo(2, length), this.RotateTo(360, length));
            this.Rotation = 0;
        }

        public async Task CardDown()
        {
            if (img.IsVisible)
            {
                img.IsVisible = false;
                frame.BackgroundColor = Color.Maroon;
            }
            else
            {
                img.IsVisible = true;
                frame.BackgroundColor = Color.White;
            }
        }


    }
}
