﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextSix.Models;
using Xamarin.Forms;

namespace TextSix.Views.DetailsViews
{
	public class CategoryListPageCS : ContentPage
    {
        public CategoryListPageCS()
        {
            Title = "Category Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var categoryItem = (CategoryItem)BindingContext;
                await App.Database.SaveCategoryAsync(categoryItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var categoryItem = (CategoryItem)BindingContext;
                await App.Database.DeleteCategoryAsync(categoryItem);
                await Navigation.PopAsync();
            };

            var deleteImageButton = new ImageButton { BindingContext = "Delete" };
            deleteImageButton.Clicked += async (sender, e) =>
            {
                var categoryItem = (CategoryItem)BindingContext;
                await App.Database.DeleteCategoryAsync(categoryItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            var speakButton = new Button { Text = "Speak" };
            speakButton.Clicked += (sender, e) =>
            {
                var bookItem = (CategoryItem)BindingContext;
                DependencyService.Get<ITextToSpeech>().Speak(bookItem.Name + " " + bookItem.Notes);
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    deleteImageButton,
                    cancelButton,
                    speakButton
                }
            };
        }
    }
}
