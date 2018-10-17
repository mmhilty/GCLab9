using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace GCLab9
{
    class Program
    {
        static void Main(string[] args)
        {
           
             //////StudentRecord newRecord = new StudentRecord(firstName, lastName, studentHobby, faveFood, shoeSize);
            StudentRecord NanaRecord = new StudentRecord("Nana","Banahene","coding","Empanadas","unknown");
            StudentRecord TimRecord = new StudentRecord("Tim","Broughton","coding","Chicken Parm", "unknown");
            StudentRecord LinZRecord = new StudentRecord("Lin-Z","Chang","coding","Ice Cream", "unknown");
            StudentRecord TaylorRecord = new StudentRecord("Taylor", "Everts", "wordsmithing","James Cordon but blue", "unknown");
            StudentRecord MichaelRecord = new StudentRecord("Michael","Hern","coding","Chicken Wings", "unknown");
            StudentRecord MadelynRecord = new StudentRecord("Madelyn","Hilty","NO COMMENT","Korean BBQ","bigfoot");
            StudentRecord JordanRecord = new StudentRecord("Jordan","Owiesny","coding","Burgers", "unknown");
            StudentRecord ShahRecord = new StudentRecord("Shah","Shahid","coding","Chicken Wings", "unknown");
            StudentRecord BlakeRecord = new StudentRecord("Blake","Shaw","coding","Cannoli", "unknown");
            StudentRecord JonRecord = new StudentRecord("Jon","Shaw","coding","Ribs", "unknown");
            StudentRecord JayRecord = new StudentRecord("Jay","Stiles","coding","Pickles", "unknown");
            StudentRecord RoachRecord = new StudentRecord("Roach","Toles","coding","Space Cheese", "unknown");
            StudentRecord BobRecord = new StudentRecord("Bob","Valentic","coding","Pizza", "unknown");
            StudentRecord AbbyRecord = new StudentRecord("Abby","Wessels","roller derby","Soup", "unknown");
            StudentRecord JoshuaRecord = new StudentRecord("Joshua","Zimmerman","coding","Turkey", "unknown");
                       
            Dictionary<string, StudentRecord> studentDictionary = new Dictionary<string, StudentRecord>()
            {
                {"BANAHENENANA",NanaRecord },
                {"BROUGHTONTIM", TimRecord },
                {"CHANGLIN-Z", LinZRecord },
                {"EVERTSTAYLOR",TaylorRecord },
                {"HERNMICHAEL", MichaelRecord },
                {"HILTYMADELYN", MadelynRecord },
                {"OWIESNYJORDAN", JordanRecord},
                {"SHAHIDSHAH", ShahRecord},
                {"SHAWBLAKE", BlakeRecord},
                {"SHAWJON", JonRecord},
                {"STILESJAY", JayRecord},
                {"TOLESROACH", RoachRecord},
                {"VALENTICBOB", BobRecord},
                {"WESSELSABBY", AbbyRecord},
                {"ZIMMERMANJOSHUA", JoshuaRecord},

            };
            
                


            bool killswitch = true;
            while (killswitch)
            {
                Console.WriteLine(@"
What would you like to do?
1. View Student Directory
2. View Student Details
3. Add a Student to Directory
4. Exit");

                string mainMenuInput = Console.ReadLine();
                if (mainMenuInput == "1")
                {
                    Console.WriteLine(@"
Student Directory
=============================================");
                    foreach (KeyValuePair<string, StudentRecord> kvp in studentDictionary.OrderBy(key => key.Key))
                    {
                        StudentRecord record = kvp.Value;
                        Console.WriteLine($"{record.firstName} {record.lastName}");
                    }
                }

                else if (mainMenuInput == "2")
                {
                    Console.WriteLine(accessRecord(studentDictionary));

                }

                else if (mainMenuInput == "3")
                {
                    studentDictionary = addRecordtoDict(studentDictionary);

                }

                else if (mainMenuInput == "4")
                {
                    killswitch = false;
                }

                else
                {
                    Console.WriteLine("That is not an option.");
                    continue;
                }

                


            }

        }


        public static string accessRecord(Dictionary<string, StudentRecord> recordDict)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine(@"
Which student do you want to get more information about?
(Enter the student's name in Firstname Lastname format)
");

                //allows student to input first and last name, creates the key from them to look up student
                string nameInput = Console.ReadLine();
              
                    List<string> regexList = new List<string>(Regex.Split(nameInput.ToUpper(), @"[ ]+"));
                    string keyInput = createKey(regexList[1], regexList[0]);

                    bool killswitch = true;
                    while (killswitch)
                    {

                        try
                        {
                            StudentRecord reffedRecord = recordDict[keyInput];
                 
                            Console.WriteLine(@"What would you like to know about the student?
1. Hobby
2. Favorite Food
3. Shoe Size

4. Choose Another Student
5. Return to Main Menu");
                                                       
                            string userInput = Console.ReadLine().ToUpper();

                            if (userInput == "1" || userInput == "HOBBY")
                            {
                                return $"{reffedRecord.firstName}'s main hobby is {reffedRecord.hobby}.";
                            }

                            else if (userInput == "2" || userInput == "FAVORITE FOOD" || userInput == "FOOD")
                            {
                                return $"{reffedRecord.firstName}'s favorite food is {reffedRecord.faveFood}.";
                            }

                            else if (userInput == "3" || userInput == "SHOE SIZE" || userInput == "SHOE")
                            {
                                return $"{reffedRecord.firstName}'s shoe size is {reffedRecord.shoeSize}.";
                            }

                            else if (userInput == "4")
                            {
                                killswitch = false;
                            }

                            else if (userInput == "5")
                            {
                                return "";
                            }

                            else
                            {
                                Console.WriteLine("Not a valid input.");
                            }
                        }

                        catch
                        {
                            Console.WriteLine("That student doesn't exist.");
                            killswitch = false;
                        }
                    }

                }

                catch
                {
                    Console.WriteLine("That student doesn't exist.");
                    
                }

                
            }
        }

        public static Dictionary<string, StudentRecord> addRecordtoDict(Dictionary<string, StudentRecord> recordDict)
        {

            string lastName = getString("last name");
            string firstName = getString("first name");
            string studentHobby = getString("hobby");
            string faveFood = getString("favorite food");
            string shoeSize = getString("shoe size");

            StudentRecord newRecord = new StudentRecord(firstName, lastName, studentHobby, faveFood, shoeSize);
            //return newRecord;


            //object record = createRecord();
            string keylastname = newRecord.lastName;
            string keyfirstname = newRecord.firstName;
            string keyLNFN = createKey(keylastname, keyfirstname);
            recordDict.Add(keyLNFN, newRecord);

            return recordDict;
        }



            /*List<string> newRecordList = new List<string>(); //creates list and fills it with records
            newRecordList.Add(lastName);
            newRecordList.Add(firstName);
            newRecordList.Add(studentHobby);
            newRecordList.Add(faveFood);
            newRecordList.Add(shoeSize);

            return newRecordList;*/

        //}

        public static string getString(string prompt) //added no entry handling
        {
            while(true)
            {
                Console.WriteLine($"What is the student's {prompt}?");
                string userInput = Console.ReadLine();
                if (userInput != "")
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("You have to put something in, buddy.");
                    continue;
                }
            }
        }
                
        public static string createKey(string lastName, string firstName) //key is ALL CAPS
        {
            string keyCreated = $"{lastName}{firstName}";
            return keyCreated.ToUpper(); 
        }

       

    }

    public class StudentRecord
    {

        public StudentRecord(string firstName, string lastName, string hobby, string faveFood, string shoeSize)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.hobby = hobby;
            this.faveFood = faveFood;
            this.shoeSize = shoeSize;

        }

        public string firstName { set; get; }
        public string lastName { set; get; }
        public string hobby { set; get; }
        public string faveFood { set; get; }
        public string shoeSize { set; get; }

    }
}
