using Microsoft.Maui.Controls;
using System;

namespace MauiApp1.Pages
{
    public partial class PillsPage : ContentPage
    {
        public PillsPage()
        {
            InitializeComponent();
        }

        // ���������� ������� �� ������� (��������)
        private async void OnCardTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                string date = "13.01.2024";
                string medicine = "������";
                string times = "08:00 - �������� �������\n20:00 - �������� �������";

                await DisplayAlert("����������",
                    $"���� ������ ��������: {date}\n������������: {medicine}\n�����:\n{times}",
                    "OK");
            }
        }

        // ���������� ������ "�������� �� �������"
        private async void OnNotTakenClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Text = "�������� �������";
                button.BackgroundColor = Color.FromHex("#1A0F42");
                button.IsEnabled = false;

                // ����� ��������������� Label � �������� �� �����
                if (button.Parent?.Parent is Grid grid)
                {
                    foreach (var child in grid.Children)
                    {
                        if (child is VerticalStackLayout timesLayout)
                        {
                            foreach (var timeChild in timesLayout.Children)
                            {
                                if (timeChild is Label timeLabel && timeLabel.Text.Contains("�������� �� �������"))
                                {
                                    timeLabel.Text = timeLabel.Text.Replace("�������� �� �������", "�������� �������");
                                    break;
                                }
                            }
                        }
                    }
                }

                await DisplayAlert("�����", "�������� ���� ������ � ����.", "OK");
            }
        }
    }
}
