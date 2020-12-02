using System;
using System.Collections.Generic;

namespace BackendProject_Cortex_EmreGok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen geçerli 4 parantezi kullanınız." +
                "'(', ')'" +
                "'[', ']'" +
                "'{', '}'" +
                "'<', '>'");

            Console.WriteLine("Bu uygulama parantezlerin doğru düzende açılıp kapanmadığını kontrol etmektedir. " +
                "Eğer yanlış sırayla parantezleri kapatırsanız FALSE, doğru sırayla kapatırsanız " +
                "TRUE olarak değer dönecektir.\n");

            Console.WriteLine("Lütfen parantezlerle bir string giriniz: ");

            string parantheses = Console.ReadLine();

            bool result = ParanthesisController(parantheses);

            Console.WriteLine("Sonuç: " + result);

            Console.WriteLine("Devam etmek için bir tuşa tıklayınız...");

            Console.ReadKey();
        }
        public static bool ParanthesisController(string parantheses)
        {
            IDictionary<char, char> controlParantheses = new Dictionary<char, char>();//Kapanış parantezlerini kontrol etmek için Kütüphane veri yapısını kullandım.

            controlParantheses.Add(')', '(');//Kütüphaneye tek tek parantez girişi yapılıyor.

            controlParantheses.Add('}', '{');

            controlParantheses.Add(']', '[');

            controlParantheses.Add('>', '<');

            if (parantheses.Length == 0)//Girilen stringin boş olup olmadığı kontrolü yapılıyor.
            {
                Console.WriteLine("Lütfen alanı boş bırakmayınız!");

                return false;
            }

            Stack<char> stack = new Stack<char>();

            try
            {
                foreach (var paranthesis in parantheses)
                {
                    if (paranthesis == '(' || paranthesis == '{' || paranthesis == '[' || paranthesis == '<')
                    {
                        stack.Push(paranthesis);
                    }

                    else if (paranthesis == ')' || paranthesis == '}' || paranthesis == ']' || paranthesis == '>')
                    {
                        if (stack.Count == 0)
                        {
                            Console.WriteLine("Hatalı sıralama! Sıralamayı kapanış paranteziyle başlatmayınız!");

                            return false;
                        }

                        if (stack.Peek() == controlParantheses[paranthesis])
                        {
                            stack.Pop();
                        }

                        else
                        {
                            Console.WriteLine("Hatalı sıralama! Açılış ve kapanış parantezlerini doğru sırayla giriniz!");

                            return false;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Geçersiz bir karakter girilmiş! Programdan çıkılıyor...");

                        return false;
                    }
                }

                if(stack.Count != 0)
                {
                    Console.WriteLine("Bazı parantezleri kapatmamışsınız!");

                    return false;
                }

                else
                {
                    Console.WriteLine("Doğru sıralama!");

                    return true;
                }
            }

            catch
            {
                Console.WriteLine("Bir hata oluştu...");

                return false;
            }
        }
    }
}
