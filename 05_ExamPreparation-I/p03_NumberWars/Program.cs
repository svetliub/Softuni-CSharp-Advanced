using System;
using System.Collections.Generic;
using System.Linq;

namespace p03_NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var secondPlayerCards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int turns = 0;
            string result = "Draw";
            bool gameOver = false;

            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && turns < 1000000 && !gameOver)
            {
                var firstCard = firstPlayerCards.Dequeue();
                var firstPlayerCard = GetNumber(firstCard);
                var secondCard = secondPlayerCards.Dequeue();
                var secondPlayerCard = GetNumber(secondCard);

                if (firstPlayerCard > secondPlayerCard)
                {
                    firstPlayerCards.Enqueue(firstCard);
                    firstPlayerCards.Enqueue(secondCard);
                }

                if (secondPlayerCard > firstPlayerCard)
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }

                if (firstPlayerCard == secondPlayerCard)
                {
                    var firstSum = 0;
                    var secondSum = 0;
                    List<string> cardsToTake = new List<string> { firstCard, secondCard };

                    while (!gameOver)
                    {

                        if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                        {
                            string q1 = firstPlayerCards.Dequeue();
                            string q2 = firstPlayerCards.Dequeue();
                            string q3 = firstPlayerCards.Dequeue();

                            cardsToTake.Add(q1);
                            cardsToTake.Add(q2);
                            cardsToTake.Add(q3);

                            char fc1 = GetChar(q1);
                            char fc2 = GetChar(q2);
                            char fc3 = GetChar(q3);

                            firstSum = firstSum + (int)fc1 + (int)fc2 + (int)fc3;

                            string sq1 = secondPlayerCards.Dequeue();
                            string sq2 = secondPlayerCards.Dequeue();
                            string sq3 = secondPlayerCards.Dequeue();

                            cardsToTake.Add(sq1);
                            cardsToTake.Add(sq2);
                            cardsToTake.Add(sq3);

                            char sc1 = GetChar(sq1);
                            char sc2 = GetChar(sq2);
                            char sc3 = GetChar(sq3);

                            secondSum = secondSum + (int)sc1 + (int)sc2 + (int)sc3;

                            cardsToTake = cardsToTake.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)).ToList();

                            if (firstSum > secondSum)
                            {
                                for (int i = 0; i < cardsToTake.Count; i++)
                                {
                                    firstPlayerCards.Enqueue(cardsToTake[i]);
                                }
                                break;
                            }

                            if (firstSum < secondSum)
                            {
                                for (int i = 0; i < cardsToTake.Count; i++)
                                {
                                    secondPlayerCards.Enqueue(cardsToTake[i]);
                                }
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }

                turns++;
            }

            if (firstPlayerCards.Count < secondPlayerCards.Count)
            {
                result = "Second player wins";
            }
            else if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                result = "First player wins";
            }

            Console.WriteLine($"{result} after {turns} turns");
        }

        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static char GetChar(string card)
        {
            return card.ToCharArray().Last();
        }
    }
}
