﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextSix.Models;
using Xamarin.Forms;

namespace TextSix.Views.DetailsViews
{
	public class CategoryItemPageCS : ContentPage
    {
        public CategoryItemPageCS()
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
                var todoItem = (CategoryItem)BindingContext;
                await App.Database.SaveCategoryAsync(todoItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var todoItem = (CategoryItem)BindingContext;
                await App.Database.DeleteCategoryAsync(todoItem);
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
                var todoItem = (BookItem)BindingContext;
                DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
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
                    cancelButton,
                    speakButton
                }
            };
        }
    }
}