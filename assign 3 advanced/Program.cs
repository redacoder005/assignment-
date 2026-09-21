namespace assign_3_advanced
{

    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("===== Exercise 1: Student Grade Manager =====");

            List<int> grades = new List<int>()
        {
            85, 92, 78, 95, 88, 70, 100, 65
        };

            Console.WriteLine("Grades:");

            foreach (int grade in grades)
            {
                Console.Write(grade + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Count: " + grades.Count);
            Console.WriteLine("First grade: " + grades[0]);
            Console.WriteLine("Last grade: " + grades[grades.Count - 1]);

            grades.Sort();

            Console.WriteLine("Sorted grades:");

            foreach (int grade in grades)
            {
                Console.Write(grade + " ");
            }

            Console.WriteLine();

            foreach (int grade in grades)
            {
                if (grade > 90)
                {
                    Console.WriteLine("First grade above 90: " + grade);
                    break;
                }
            }

            Console.WriteLine("Failing grades:");

            foreach (int grade in grades)
            {
                if (grade < 75)
                {
                    Console.Write(grade + " ");
                }
            }

            Console.WriteLine();

            grades.RemoveAll(grade => grade < 75);

            Console.WriteLine("After removing failing grades:");

            foreach (int grade in grades)
            {
                Console.Write(grade + " ");
            }

            Console.WriteLine();

            if (grades.Contains(100))
            {
                Console.WriteLine("There is a grade equal to 100");
            }
            else
            {
                Console.WriteLine("There is no grade equal to 100");
            }

            List<string> gradeText = new List<string>();

            foreach (int grade in grades)
            {
                gradeText.Add("Grade: " + grade);
            }

            Console.WriteLine("Grade strings:");

            foreach (string text in gradeText)
            {
                Console.WriteLine(text);
            }


            

            Console.WriteLine();
            Console.WriteLine("===== Exercise 2: Leaderboard =====");

            SortedDictionary<int, string> players =
                new SortedDictionary<int, string>();

            players.Add(500, "Ahmed");
            players.Add(200, "Sara");
            players.Add(800, "Ali");
            players.Add(350, "Mona");

            Console.WriteLine("Leaderboard:");

            foreach (KeyValuePair<int, string> player in players)
            {
                Console.WriteLine(player.Key + " = " + player.Value);
            }

            foreach (KeyValuePair<int, string> player in players)
            {
                Console.WriteLine("First key: " + player.Key);
                Console.WriteLine("First value: " + player.Value);
                break;
            }

            if (players.ContainsKey(500))
            {
                Console.WriteLine("Score 500 exists");
            }

            string playerName;

            if (players.TryGetValue(999, out playerName))
            {
                Console.WriteLine("Player: " + playerName);
            }
            else
            {
                Console.WriteLine("Score 999: Not Found");
            }

            players.Remove(200);

            Console.WriteLine("After removing score 200:");

            foreach (KeyValuePair<int, string> player in players)
            {
                Console.WriteLine(player.Key + " = " + player.Value);
            }


            Console.WriteLine();
            Console.WriteLine("===== Exercise 3: Phone Book =====");

            Dictionary<string, string> phoneBook =
                new Dictionary<string, string>();

            phoneBook.Add("Ahmed", "01011111111");
            phoneBook.Add("Sara", "01022222222");
            phoneBook.Add("Mona", "01033333333");
            phoneBook.Add("Ali", "01044444444");

            phoneBook["Omar"] = "01055555555";

            try
            {
                phoneBook.Add("Ahmed", "01099999999");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            bool added = phoneBook.TryAdd("Ahmed", "01099999999");

            Console.WriteLine("TryAdd succeeded: " + added);

            if (phoneBook.ContainsKey("Khaled"))
            {
                Console.WriteLine("Khaled exists");
            }
            else
            {
                Console.WriteLine("Khaled not found");
            }

            string phone = phoneBook.GetValueOrDefault(
                "Khaled", "Not Found");

            Console.WriteLine("Khaled phone: " + phone);

            Console.WriteLine("Names:");

            foreach (string name in phoneBook.Keys)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Phone numbers:");

            foreach (string number in phoneBook.Values)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();


           

            Console.WriteLine();
            Console.WriteLine("===== Exercise 4: Unique Email Validator =====");

            HashSet<string> emails =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine("Email count: " + emails.Count);

            Console.WriteLine("Emails:");

            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Count is 2 because duplicate emails with different capitalization are treated as the same.");

            HashSet<int> setA =
                new HashSet<int>() { 1, 2, 3, 4, 5 };

            HashSet<int> setB =
                new HashSet<int>() { 4, 5, 6, 7, 8 };

            HashSet<int> unionSet = new HashSet<int>(setA);
            unionSet.UnionWith(setB);

            Console.WriteLine("Union:");

            foreach (int number in unionSet)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            HashSet<int> intersectSet = new HashSet<int>(setA);
            intersectSet.IntersectWith(setB);

            Console.WriteLine("Intersection:");

            foreach (int number in intersectSet)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            HashSet<int> exceptSet = new HashSet<int>(setA);
            exceptSet.ExceptWith(setB);

            Console.WriteLine("Except:");

            foreach (int number in exceptSet)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            HashSet<int> smallSet =
                new HashSet<int>() { 1, 2 };

            Console.WriteLine(
                "Is {1,2} subset of Set A: "
                + smallSet.IsSubsetOf(setA)
            );


            

            Console.WriteLine();
            Console.WriteLine("===== Exercise 5: Print Queue =====");

            Queue<string> documents = new Queue<string>();

            documents.Enqueue("Report.pdf");
            documents.Enqueue("Invoice.pdf");
            documents.Enqueue("Letter.docx");
            documents.Enqueue("Resume.pdf");
            documents.Enqueue("Photo.jpg");

            Console.WriteLine("Queue:");

            foreach (string document in documents)
            {
                Console.WriteLine(document);
            }

            Console.WriteLine("Count: " + documents.Count);
            Console.WriteLine("Next document: " + documents.Peek());

            while (documents.Count > 0)
            {
                string document = documents.Dequeue();

                Console.WriteLine("Printing: " + document);
            }

            string nextDocument;

            if (documents.TryDequeue(out nextDocument))
            {
                Console.WriteLine("Printing: " + nextDocument);
            }
            else
            {
                Console.WriteLine("Queue is empty");
            }


           

            Console.WriteLine();
            Console.WriteLine("===== Exercise 6: Browser History =====");

            Stack<string> history = new Stack<string>();

            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            Console.WriteLine("Current page: " + history.Peek());

            for (int i = 0; i < 3; i++)
            {
                string page = history.Pop();

                Console.WriteLine("Leaving: " + page);
            }

            Console.WriteLine("Current page after back: " + history.Peek());

            Stack<string> emptyHistory = new Stack<string>();

            string currentPage;

            if (emptyHistory.TryPop(out currentPage))
            {
                Console.WriteLine("Page: " + currentPage);
            }
            else
            {
                Console.WriteLine("Stack is empty");
            }
        }
    }
}
