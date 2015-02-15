using System;
using QuienEsQuien.Models;
using QuienEsQuien.Services;
using Xamarin.Forms;

namespace QuienEsQuien.Pages
{
    public class PlayPage : ContentPage
    {
        static readonly int NUM = 4;
        

        StackLayout stackLayout;
        AbsoluteLayout absoluteLayout;
        Button randomizeButton;
        Label timeLabel;
        double cardSize;
        bool isBusy;
        bool isPlaying;

        private AzureMobileService service;
        

        public int Player { get; set; }


        public PlayPage()
        {
            service = new AzureMobileService();
            Player = new Random().Next(1, 15);

       
            absoluteLayout = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            int index = 0;

            for (int row = 0; row < NUM; row++)
            {
                for (int col = 0; col < NUM; col++)
                {
                    Card square = new Card(index)
                    {
                        Row = row,
                        Col = col
                    };

                    // Add tap recognition
                    var tapGestureRecognizer = new TapGestureRecognizer
                    {
                        Command = new Command(OnSquareTapped),
                        CommandParameter = square
                    };

                    square.GestureRecognizers.Add(tapGestureRecognizer);
                    absoluteLayout.Children.Add(square);
                    index++;
                }
            }

            var list = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Gray, 
            };

            foreach (var item in InitDb.GetQuestions())
            {
                list.Items.Add(item.Text);
            }

            list.SelectedIndex = 3;

            var lblResult = new Label
            {
                Font = Font.SystemFontOfSize(40, FontAttributes.Bold), TextColor = Color.Red, Text = "--",
                HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center
            };
            var btn = new Button { HorizontalOptions = LayoutOptions.End, 
                Text = "Enviar", TextColor = Color.Black, 
                BorderColor = Color.Accent };

            btn.Clicked += async (sender, args) =>
            {
                lblResult.Text = "--";
                lblResult.Text = await service.IsQuestion(list.SelectedIndex.ToString(), Player);
            }; 

            var user2 = GetFrame("QuienEsQuien.img.Init.png");

            // Put everything in a StackLayout.
            stackLayout = new StackLayout
            {
                BackgroundColor = Color.White,
                Children = 
                {
                    new StackLayout
                    {
                        Padding = new Thickness(10, 10, 10, 0),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = 
                        {
                            new StackLayout
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                Orientation =  StackOrientation.Horizontal, Children = { user2 }
                            },
                            new StackLayout
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Orientation =  StackOrientation.Horizontal, Children = { list, btn, lblResult }
                            }
                            //randomizeButton,
                            //timeLabel
                        }
                    },
                    absoluteLayout
                }
            };
            stackLayout.SizeChanged += OnStackSizeChanged;

            // And set that to the content of the page.
            this.Padding =
                new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.Content = stackLayout;
        }

        async void OnSquareTapped(object parameter)
        {
            if (isBusy)
                return;

            isBusy = true;
            Card tappedSquare = (Card)parameter;

            if(tappedSquare.Index+1 == Player)
                await tappedSquare.AnimateWinAsync();
            else
                await tappedSquare.AnimateSelectAsync();

            isBusy = false;
        }
        private Frame GetFrame(string img)
        {
            var image = new Image()
            {
                Source = ImageSource.FromResource(img),
                Aspect = Aspect.AspectFit
            };

            return new Frame
            {
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                OutlineColor = Color.Accent,
                Padding = new Thickness(5, 10, 5, 0),
                Content = new StackLayout
                {

                    Spacing = 0,
                    Children = 
                        {
                            image
                        }
                }
            };
        }
        void OnStackSizeChanged(object sender, EventArgs args)
        {
            double width = stackLayout.Width;
            double height = stackLayout.Height;

            if (width <= 0 || height <= 0)
                return;

            // Orient StackLayout based on portrait/landscape mode.
            stackLayout.Orientation = (width < height) ? StackOrientation.Vertical :
                                                         StackOrientation.Horizontal;

            // Calculate square size and position based on stack size.
            cardSize = Math.Min(width, height) / NUM;
            absoluteLayout.WidthRequest = NUM * cardSize;
            absoluteLayout.HeightRequest = NUM * cardSize;
            Font font = Font.SystemFontOfSize(0.4 * cardSize, FontAttributes.Bold);

            foreach (View view in absoluteLayout.Children)
            {
                var card = (Card)view;
                //square.Font = font;

                AbsoluteLayout.SetLayoutBounds(card,
                    new Rectangle(card.Col * cardSize,
                                  card.Row * cardSize,
                                  cardSize,
                                  cardSize));
            }
        }

        private void InitDbData()
        {
            //foreach (var item in InitDb.GetQuestions())
            //{
            //    await _azureClient.GetTable<Question>().InsertAsync(item);
            //}
            //foreach (var item in InitDb.GetSimpson())
            //{
            //    await _azureClient.GetTable<Simpson>().InsertAsync(item);
            //}
        }
    }
}
