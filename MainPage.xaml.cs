using System.Diagnostics;

namespace MAUI_Perf_Test
{
    public partial class MainPage : ContentPage
    {
        private readonly Random rnd = new();
        private readonly Stopwatch watcher = new();

        private List<double> numSamples = new();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                watcher.Start();
                parentGrid.Clear();
                var currentGrid = parentGrid;
                var length = 100;
                int.TryParse(numNodes.Text, out length);

                watcher.Reset();
                watcher.Start();
                for (int x = 0; x < length; x++)
                {
                    var newGrid = new Grid()
                    {
                        Padding = 2,
                        BackgroundColor = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), 255)
                    };

                    currentGrid.Add(newGrid);
                    currentGrid = newGrid;
                }
                watcher.Stop();
                numSamples.Add(watcher.ElapsedMilliseconds);
            }

            elapsedMsText.Text = $"{numSamples.Count} tests took {numSamples.Sum()}ms with average test time of {numSamples.Average()}.";
        }
    }

}
