using System;
using Xamarin.Forms;

namespace PMUclock
{
    public partial class MainPage : ContentPage
    {
        
        const int horzDots = 41;
        const int vertDots = 7; 


        readonly int[, ,] numberPatterns = new int[10, 7, 5] 
                
        {
            {
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1} 
            },
            {
                { 0, 0, 1, 0, 0}, 
                { 0, 1, 1, 0, 0}, 
                { 1, 0, 1, 0, 0}, 
                { 0, 0, 1, 0, 0}, 
                { 0, 0, 1, 0, 0}, 
                { 0, 0, 1, 0, 0}, 
                { 0, 1, 1, 1, 0} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 0}, 
                { 1, 0, 0, 0, 0}, 
                { 1, 1, 1, 1, 1} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 1, 1, 1, 1},
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1} 
            },
            {
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 0}, 
                { 1, 0, 0, 0, 0}, 
                { 1, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 0}, 
                { 1, 0, 0, 0, 0}, 
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1} 
            },
            {
                { 1, 1, 1, 1, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 0, 0, 0, 0, 1}, 
                { 1, 1, 1, 1, 1} 
            },
        };

       
        readonly int[,] colonPattern = new int[7, 2] 
        
        {
            { 0, 0 }, 
            { 0, 0 }, 
            { 0, 1 }, 
            { 0, 0 }, 
            { 0, 0 }, 
            { 0, 1 }, 
            { 0, 0 }
        };


        BoxView[, ,] digitBoxViews = new BoxView[6, 7, 5];

        const double spacing = 0.85; 
        public MainPage()
        {
            InitializeComponent();

            double height = spacing / vertDots;
            double width = spacing / horzDots;

            double xIncrement = 1.0 / (horzDots - 1); 
            double yIncrement = 1.0 / (vertDots - 1); 
            double x = 0;

            for (int digit = 0; digit < 6; digit++)
            {
                for (int col = 0; col < 5; col++)
                {
                    double y = 0;
                    
                    for (int row = 0; row < 7; row++)
                    {
                        
                        BoxView boxView = new BoxView();
                        digitBoxViews[digit, row, col] = boxView;
                        absoluteLayout.Children.Add(boxView, 
                                                    new Rectangle(x, y, width, height),
                                                    AbsoluteLayoutFlags.All);
                        y += yIncrement;
                    }
                    x += xIncrement;
                }
                x += xIncrement;
               
                        if (digit == 1 || digit == 3)
                {
                    int colon = digit / 2;

                    for (int col = 0; col < 2; col++)
                    {
                        double y = 0;

                        for (int row = 0; row < 7; row++)
                        {
                         
                            BoxView boxView = new BoxView
                                {
                                    Color = colonPattern[row, col] == 1 ? 
                                                colOn : colorOff
                                };
                            absoluteLayout.Children.Add(boxView,
                                                        new Rectangle(x, y, width, height),
                                                        AbsoluteLayoutFlags.All);
                            y += yIncrement;
                        }
                        x += xIncrement;
                    }
                    x += xIncrement;
                }
            }

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimer);
            OnTimer();
        }
        
       
        readonly Color colOn = Color.FromHex("#BF8D30");
        readonly Color colorOff = Color.Transparent;

        
        void OnPageSizeChanged(object sender, EventArgs args)
        {
            /* задаем высоту элемента часов */
            absoluteLayout.HeightRequest = vertDots * Width / horzDots;
        }
   
        bool OnTimer()
        {
            DateTime dateTime = DateTime.Now;

                       
          
            SetDotMatrix(0, dateTime.Hour / 10); 
            SetDotMatrix(1, dateTime.Hour % 10);
            SetDotMatrix(2, dateTime.Minute / 10);
            SetDotMatrix(3, dateTime.Minute % 10);
            SetDotMatrix(4, dateTime.Second / 10);
            SetDotMatrix(5, dateTime.Second % 10);
            return true;
        }

        void SetDotMatrix(int index, int digit)
        {
            for (int row = 0; row < 7; row++)
                for (int col = 0; col < 5; col++)
                {
                    bool isOn = numberPatterns[digit, row, col] == 1;
                    Color color = isOn ? colOn : colorOff;
                    digitBoxViews[index, row, col].Color = color;
                }
        }
    }
}
