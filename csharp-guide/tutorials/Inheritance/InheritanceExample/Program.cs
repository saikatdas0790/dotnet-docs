﻿using System;
using static System.Console;

namespace InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("The Tempest", "0971655819", "Shakespeare, William", "Public Domain Press");
            ShowPublicationInfo(book);
            book.Publish(new DateTime(2016, 8, 18));
            ShowPublicationInfo(book);

            var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");
            Write($"{book.Title} and {book2.Title} are the same publication: {((Publication) book).Equals(book2)}");
        }

        private static void ShowPublicationInfo(Publication pub)
        {
            string pubDate = pub.GetPublicationDate();
            WriteLine($"{pub.Title}, {(pubDate == "NYP" ? "Not Yet Published" : $"published on {pubDate}"):d} by {pub.Publisher}");
        }
    }
}
