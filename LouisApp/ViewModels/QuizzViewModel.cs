namespace LouisApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Microsoft.Maui.Controls; 

    public class QuizzViewModel : BaseViewModel
    {
        private readonly Random _random = new Random();
        private int _score;
        private string _countryName;
        private ObservableCollection<string> _flagOptions;
        private string _selectedFlag;
        private string _correctFlag;
        private int _lives;
        private bool _gameOver;

        public string CountryName
        {
            get => _countryName;
            set => SetProperty(ref _countryName, value);
        }

        public ObservableCollection<string> FlagOptions
        {
            get => _flagOptions;
            set => SetProperty(ref _flagOptions, value);
        }

        public string SelectedFlag
        {
            get => _selectedFlag;
            set => SetProperty(ref _selectedFlag, value);
        }

        public int Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        public int Lives
        {
            get => _lives;
            set => SetProperty(ref _lives, value);
        }

        public bool GameOver
        {
            get => _gameOver;
            set => SetProperty(ref _gameOver, value);
        }

        public ICommand CheckAnswerCommand { get; }
        public ICommand RestartGameCommand { get; }

        public QuizzViewModel()
        {
            InitializeGame();
            
            CheckAnswerCommand = new Command<string>(flag =>
            {
                if (GameOver) return;
                SelectedFlag = flag;
                CheckAnswer();
            });
            
            RestartGameCommand = new Command(() => InitializeGame());
        }

        private void InitializeGame()
        {
            Score = 0;
            Lives = 3;
            GameOver = false;
            FlagOptions = new ObservableCollection<string>();
            LoadNewQuestion();
        }

        public void LoadNewQuestion()
        {
            var countries = new List<(string, string)>
            {
                ("France", "🇫🇷"),
                ("Germany", "🇩🇪"),
                ("Italy", "🇮🇹"),
                ("Spain", "🇪🇸"),
                ("United States", "🇺🇸"),
                ("United Kingdom", "🇬🇧"),
                ("Russia", "🇷🇺"),
                ("Japan", "🇯🇵"),
                ("Canada", "🇨🇦"),
                ("Australia", "🇦🇺")
            };

            var correctAnswer = countries[_random.Next(countries.Count)];

            CountryName = correctAnswer.Item1;
            _correctFlag = correctAnswer.Item2;
            
          
            var options = new List<string> { _correctFlag };
            
            var availableFlags = countries
                .Select(c => c.Item2)
                .Where(f => f != _correctFlag)
                .ToList();
            
            while (options.Count < 4 && availableFlags.Count > 0)
            {
                var randomIndex = _random.Next(availableFlags.Count);
                var flag = availableFlags[randomIndex];
                availableFlags.RemoveAt(randomIndex);
                options.Add(flag);
            }
            
            FlagOptions = new ObservableCollection<string>(options.OrderBy(x => _random.Next()));
        }

        public async void CheckAnswer()
        {
            bool isCorrect = (SelectedFlag == _correctFlag);
            
            if (isCorrect)
            {
                Score++;
                await Application.Current.MainPage.DisplayAlert("Correct!", "Bonne réponse!", "Continuer");
            }
            else
            {
                Lives--;
                await Application.Current.MainPage.DisplayAlert("Incorrect", 
                    $"Mauvaise réponse. Il vous reste {Lives} vie(s).", "Continuer");
                
                if (Lives <= 0)
                {
                    GameOver = true;
                    await Application.Current.MainPage.DisplayAlert("Game Over", 
                        $"Partie terminée! Votre score final est {Score}.", "Recommencer");
                    InitializeGame();
                    return;
                }
            }
            
            LoadNewQuestion();
        }
    }
}