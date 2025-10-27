using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using CleanDesk.Services;

namespace CleanDesk.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // ====== PROPERTIES ======
        private string _status = "Ready";
        private float _cpuUsage;
        private float _ramFree;

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public float CpuUsage
        {
            get => _cpuUsage;
            set
            {
                if (Math.Abs(_cpuUsage - value) > 0.01)
                {
                    _cpuUsage = value;
                    OnPropertyChanged();
                }
            }
        }

        public float RamFree
        {
            get => _ramFree;
            set
            {
                if (Math.Abs(_ramFree - value) > 0.01)
                {
                    _ramFree = value;
                    OnPropertyChanged();
                }
            }
        }

        // ====== COMMANDS ======
        public ICommand CleanCommand { get; }
        public ICommand FreeRamCommand { get; }

        // ====== PRIVATE MEMBERS ======
        private readonly SystemMonitor _monitor;
        private readonly DispatcherTimer _timer;

        // ====== CONSTRUCTOR ======
        public MainViewModel()
        {
            _monitor = new SystemMonitor();

            CleanCommand = new RelayCommand(RunFullCleanup);
            FreeRamCommand = new RelayCommand(FreeRam);

            // Auto-refresh CPU & RAM every 2 seconds
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            _timer.Tick += (s, e) => UpdateSystemStats();
            _timer.Start();
        }

        // ====== METHODS ======
        private void UpdateSystemStats()
        {
            var (cpu, ram) = _monitor.GetStats();
            CpuUsage = cpu;
            RamFree = ram;
        }

        private void RunFullCleanup()
        {
            Status = "🧹 Cleaning system...";
            OnPropertyChanged(nameof(Status));

            try
            {
                long totalFreed = 0;
                totalFreed += FileCleaner.CleanTempFiles();
                totalFreed += BrowserCleaner.CleanBrowserCache();

                Status = $"✅ Cleanup complete. Freed {totalFreed / 1024 / 1024:N1} MB.";
            }
            catch (Exception ex)
            {
                Status = $"⚠️ Cleanup failed: {ex.Message}";
            }
        }

        private void FreeRam()
        {
            Status = "⚡ Freeing memory...";
            OnPropertyChanged(nameof(Status));

            try
            {
                int optimized = RamOptimizer.FreeMemory();
                Status = $"✅ RAM optimized for {optimized} processes.";
            }
            catch (Exception ex)
            {
                Status = $"⚠️ RAM optimization failed: {ex.Message}";
            }
        }

        // ====== INotifyPropertyChanged ======
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
