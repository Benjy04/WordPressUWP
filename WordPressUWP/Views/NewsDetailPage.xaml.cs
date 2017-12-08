﻿using System;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WordPressUWP.ViewModels;

namespace WordPressUWP.Views
{
    public sealed partial class NewsDetailPage : Page
    {
        private NewsDetailViewModel ViewModel
        {
            get { return DataContext as NewsDetailViewModel; }
        }

        public NewsDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.SelectedPost = e.Parameter as WordPressPCL.Models.Post;
            await ViewModel.Init();
        }

        private void CommentToggleButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            bool showCommentInput = CommentToggleButton.IsChecked ?? false;
            ToggleCommentInput(showCommentInput);
        }

        private void ToggleCommentInput(bool show)
        {
            CommentToggleButton.IsChecked = show;
            if (show)
            {
                CommentInputGrid.Height = double.NaN;
            }
            else
            {
                CommentInputGrid.Height = 0;
            }
        }

        private void ReplyButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (sender is HyperlinkButton button)
            {
                if (button.Tag is WordPressPCL.Models.CommentThreaded comment)
                {
                    ViewModel.CommentReply = comment;
                    ToggleCommentInput(true);
                }
            }
        }
    }
}
