using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum GenderIdentity
{
    Male,
    Female,
    Other
}

public enum MarriageStatus
{
    Single,
    Married,
    Widower,
    Divorced
}

public class User : MonoBehaviour
{
    public new string name;
    public int age;
    public GenderIdentity genderIdentity;
    public string email;
    public string phoneNumber;
    public string education;
    public string occupation;
    public int experience;
    public List<String> hobbies;
    public int salary;
    public int savings;
    public int debt;
    public int creditScore;
    public MarriageStatus marriageStatus;
    public int children;
    public List<string> searchHistory;
    
    public Dictionary<string, object> userAttributes = new Dictionary<string, object>();

    public int seed = 0;

    public void OnValidate()
    {
        if (!IsLoaded)
        {
            AllUserData = CSVReader.Read("RandomUsers");
            IsLoaded = true;
        }
    }

    public void Awake()
    {
        //GenerateUser();
    }

    public void Start()
    {

    }

    public void GenerateUser()
    {

        hobbies.Clear();
        searchHistory.Clear();
        
        userAttributes.Clear();

        if (!IsLoaded)
        {
            AllUserData = CSVReader.Read("RandomUsers");
            IsLoaded = true;
        }
        
        
        Dictionary<string, object> entry = AllUserData[Random.Range(0, AllUserData.Count)];
        name = entry["First Name"].ToString() + " " + entry["Last Name"].ToString();
        //check if cast is valid
        age = int.TryParse(entry["Age"].ToString(), out age) ? age : 27;
        email = entry["Email"].ToString();
        phoneNumber = entry["Phone"].ToString();
        education = entry["Education"].ToString();
        occupation = entry["Occupation"].ToString();
        experience = int.TryParse(entry["Experience (Years)"].ToString(), out experience) ? experience : 3;
        salary = int.TryParse(entry["Salary"].ToString(), out salary) ? salary : 50000;
        children = int.TryParse(entry["Number of Children"].ToString(), out children) ? children : 0;

        //Marriage Status
        int marriage = Random.Range(0, 10);
        if (marriage < 2)
        {
            marriageStatus = MarriageStatus.Widower;
        }
        else if (marriage < 5)
        {
            marriageStatus = MarriageStatus.Divorced;
        }
        else if (marriage < 8)
        {
            marriageStatus = MarriageStatus.Married;
        }
        else
        {
            marriageStatus = MarriageStatus.Single;
        }

        //Identity
        string gender = entry["Gender"].ToString();
        if (gender == "Male") genderIdentity = GenderIdentity.Male;
        if (gender == "Female") genderIdentity = GenderIdentity.Female;
        if (Random.Range(0, 10) < 2) genderIdentity = GenderIdentity.Other;
        
        //Hobbies
        for (int i = 0; i < 3; i++)
        {
            hobbies.Add(AllHobbies[Random.Range(0, AllHobbies.Length)]);
        }
        
        //Savings & Debt
        debt = Random.Range(0, 100000);
        savings = (int) ((experience/2) * (salary) * Random.Range(0.0f, 0.2f));
        if (savings > debt)
        {
            savings -= debt;
            debt = (int) Random.Range(0, debt * 0.1f);
        }
        else if (savings < debt)
        {
            debt -= savings;
            savings = (int) Random.Range(0, salary * 0.25f);
        }
        else
        {
            debt = (int) Random.Range(0, debt * 0.1f);
            savings = (int) Random.Range(0, salary * 0.25f);;
        }
        
        // Credit Score
        creditScore = 500;
        creditScore += (int) (savings * 0.002f);
        creditScore -= (int) (debt * 0.003f);
        creditScore += Random.Range(-100, 100);
        if (creditScore < 300) creditScore = 300;
        if (creditScore > 850) creditScore = 850;

        //Search history
        for (int i = 0; i < 8; i++)
        {
            searchHistory.Add(AllSearchHistories[Random.Range(0, AllSearchHistories.Length)]);
        }

        // Correct years of experience
        if (age - experience < 18)
        {
            experience = age - 18;
        }
        
        // Correct number of children
        if (age - children < 18)
        {
            children = age - 18;
        }
        

    }

    private static List<Dictionary<string, object>> AllUserData;
    private static bool IsLoaded = false;

    public static string[] AllHobbies =
    {
        "Bird Watching", "Horse Riding", "Diving", "Hiking", "Biking", "Walking", "Running", "Singing", "Dancing", "Heavy Metal", "True Crime",
        "Recreational Drugs", "Meditation", "Yoga", "Gardening", "Cooking", "Reading", "Writing", "Painting", "Drawing", "Sculpting", "Knitting",
        "Crocheting", "Sewing", "Embroidery", "Woodworking", "Metalworking", "Pottery", "Ceramics", "Glassblowing", "Jewelry Making", "Photography",
        "Fencing", "Smoking Meats", "Homebrewing", "Brewing Beer", "Brewing Wine", "Brewing Cider", "Brewing Mead", "Brewing Kombucha", "Brewing Coffee",
        "Skydiving", "Thrillseeking", "Gaming", "Board Games", "Card Games", "Roleplaying Games", "Video Games", "Tabletop Games", "Collecting",
        "Gambling", "Alcoholism", "Petty Crimes", "Livestreaming", "Podcasting", "Blogging", "Vlogging", "Journaling", "Journalism", "Politics", "Programming",
        "Coding", "Mathematics", "Physics", "Chemistry", "Biology", "Astronomy", "Geology", "History", "Philosophy", "Psychology", "Sociology", "Anthropology",
    };

    public static string[] AllSearchHistories =
    {
        "how to do origami", "how to get a 6 pack", "why am i ugly", "food near me", "how to be less lonely", "free money",
        "how to get a girlfriend", "how to get a boyfriend", "how to get a sugar daddy", "how to get a sugar momma", "how to get a sugar baby",
        "mount everest facts", "how to get a job", "how to get a promotion", "how to get a raise", "how to get a better job", "how to get a better salary",
        "cheap accountants", "where to dispose of a body", "how to hack", "how to hack a bank", "how to hack a computer", "how to hack a phone",
        "how to sell a stolen laptop", "how to delete my sons minecraft world", "beach ladies", "celebrity feet", "among us free download", "minecraft free download",
        "how to be less amazing", "signs of narcissism", "am i pregnant or full of soup", "top 10 soup recipes", "how to make a soup", "how to make a sandwich",
        "top 10 anime betrayals", "cool anime wallpapers", "new tech gadgets", "how to make a website", "how to make a website for free", "how to make a website for free and easy",
        "how to code", "how to code a website", "how to code a game", "how to code a game in unity", "how to code a game in unreal engine", "how to code a game in godot",
        "is social media tracking me", "how to stop social media tracking me", "how to stop social media tracking me for free", "how to stop social media tracking me for free and easy",
        "how to stop social media tracking me for free and easy and fast", "how to stop social media tracking me for free and easy and fast and without a degree",
        "how to stop social media tracking me for free and easy and fast and without a degree and without a job", "how to stop social media tracking me for free and easy and fast and without a degree and without a job and without a life",
        "how to stop social media tracking me for free and easy and fast and without a degree and without a job and without a life and without a soul",
        "how do i get my soul back", "where did dad go", "therapy online free", "therapy online free and easy", "therapy online free and easy and fast",
        "how to grow a tree", "best smartphones", "is debt actually bad", "how to die without pain", "can a virgo date a virgo", "how to get a girlfriend if you are a virgo",
        "do vaccines cause autism", "why vaccinations are bad", "who is in the shadow government", "how to use 4 ripe avocados today", "symptoms of depression", "sore left arm",
        "pain in chest", "when to call an ambulance", "does jet fuel melt steel beams", "what is really in area 51", "my cat wont shut up", "does my cat hate me",
        "how to get my cat to come back home", "my cat is possessed by the devil", "is my cat actually a dog", "phone sex", "is it normal to have suicidal thoughts",
        "300 chinese finger traps buy now", "how to get out of the 300 chinese finger traps i bought last week", "cheap flights", "companies hiring near me", "secretary jobs",
        "how to screenshot", "speak korean 5 easy steps", "how do trains work", "is the black plague gone", "why is the sky blue", "why does china want taiwan", "who does devi end up with season 3",
        "free movies", "watch movies online free no download", "free movies no virus", "how to get free movies without anyone knowing", "are pisces and leo compatible", "can searching up symptoms cause symptoms",
        "placebo effect", "rash on chest", "small red spot on leg", "how to get rid of a pimple fast", "waxy ears", "how to fix waxy ears", "showers that have a pulpy option", "pulpy showers",
        "how to make money from ai generated art", "is it ok to have no friends", "how to make friends", "why dont my friends contact me", "can you get pregnant on your period", "will i ever find love",
        "big honkers", "how do you get pneumonia", "why does my eye keep twitching", "how to get out of work tomorrow", "how to call in sick to work", "where do babies come from",
        "std testing near me", "feet smell like cheese", "feet flaking", "lol cats", "cool cat breeds", "da dada da da do do da do da song", "what is the song that goes dadadadad da dad daad dda dada",
        "can i own a capybara", "how many weeks in a year", "how many days until christmas", "how many calories should i be eating", "bmi calculator", "am i overweight", "am i underweight",
        "why should you wash rice", "how to write a cv", "is god real", "bible read online free", "bible online no virus", "bible activity sheet for kids", "is it ok to eat sprouted potatoes",
        "road rules", "who has right of way", "petrol prices", "why is the price of food going up", "why does it hurt to pee", "how to vote", "why does my stomach hurt", "is it ok to still love my ex",
        "why do i keep getting UTIs", "why do men sneeze so loudly", "news", "news today", "why doesnt everyone speak english", "how to speak english", "how to speak english fluently",
        "how to floss", "how to numb the pain", "how to stop someone choking", "can i eat soap", "why dont people like me", "conspiracy theories", "is the sun real", "are birds real", "flat earth", "is the earth flat",
        "proof the earth is flat", "what happened to the dinosaurs", "where are all the dinosaurs", "bees", "dinosaur facts", "dinosaur facts for kids", "dinosaur facts for adults", "top 10 dinosaurs",
        "how to center a div", "what is among us", "how to tell that the impostor is sus", "why is my hair damaged", "pet chicken for sale", "washing machine making screeching noise",
        "washing machine broken", "how to wash clothes by hand", "can i leave society", "how to survive in the wild", "going off the grid", "why do we need money", "life hacks", "top 10 life hacks",
        "what to do when you are bored", "top 10 easy life hacks with household objects", "how to move my mother to a retirement home", "can i put my parents up for adoption", "funny jokes", "top 10 jokes",
        "original jokes", "joke punch lines", "how to build a house by hand", "what to do when someone dies", "what to do when someone has a seizure", "pink ice cream cones", "top 10 ice cream brands",
        "why cant i sleep", "how to get to sleep", "why can i smell smoke", "why can i smell burning toast", "signs of a stroke", "signs of cancer", "is fast food vegan or vegetarian",
        "why do people cheat", "why do people steal", "how to access the dark web", "the onion", "financial planner", "how to budget", "how to budget for traveling", "what are actually true facts about yourself",
        "why doesnt rick astley have any wrinkles", "is star wars actually an allegory for facism", "top 10 facist leaders", "top 10 facist movies", "top 10 facist actors", "snapple facts", "what to do when someone dies",
        "why do i fart so much", "wedding costs", "can i still drink if im pregnant", "should i drink if im pregnant", "can i drink if im pregnant", "distance from paris to berlin",
        "distance from germany to france", "is love actually real", "how to meet someone in quarantine", "is life really only a dream", "how to know youre still dreaming",
        "how to wake up from a dream", "how to know its all just a dream", "why is my phone so slow", "my back hurts", "allergy advice", "how to stop allergies", "baby names", "petsmart",
        "what is blockchain technology", "how to teach her", "does size really matter", "how to actually teach someone", "how to sleep", "why is the red sky red", "why is the ocean salty",
        "why do cats meow so much", "can i rescue a heathcliff cat", "does dairy free ice cream have calories", "why dont cats eat ice cream", "where does the butter go when its frozen",
        "how to stop symptoms from an STD", "what if brain tumors are real", "what to do if you have a brain tumor", "is cancer ever ok", "what if brain tumors are good for your brain",
        "lol", "iced tea recipe", "can i eat expired food", "can i eat expired chocolate", "why does my eardrum feel like its going to burst", "why is my eardrum sensitive",
        "where do I get my sense of hearing from", "how do I keep my ears clean", "can i sell my kidneys", "human ear", "human ear anatomy", "what is an ear", "mayonnaise is gross",
        "humans are gross", "dogs are the best", "cats are the best", "how to buy a smartphone", "what is a smartphone", "why dont i want to drink alcohol", "how to stop being sad",
        "can i put a smart phone in my brain", "what is a heathcliff cat", "where does all my money go", "do i have to pay tax", "how to not pay tax", "maximum sentence for tax fraud",
        "ear pictures", "why does nobody take me seriously", "why is the sky blue", "what does /s mean", "what does /j mean", "what is a tone indicator", "why are people so sensitive",
        "how to sue someone", "how to get out of jury duty", "whale facts", "black spider with striped legs", "spider identification", "what is KEKW", "what is a pog", "how to tell if you are having a strooooooooooooooooo",
        "why doesnt my streamer respond to me", "how much money do streamers make", "only fans", "milk alternatives", "egg alternatives", "how to go vegan", "why are vegans bad", "should i get therapy",
        "how to get therapy", "where do i find a therapist", "i want to squeeze my cat", "why do i want to squeeze my cat", "why do i want to squeeze my cat so much",
        "cat roleplay ideas", "free games online no virus", "free games online no download", "free games online no ads", "free games online no sign up", "free games online no download no virus",
        "are ads watching me", "how to stop ads from watching me", "how to stop ads from watching me on my phone", "how to stop ads from watching me on my computer", "how to stop ads from watching me on my tv",
        "are ads bad", "are ads good", "are ads good for you", "are ads bad for you", "are ads good for the economy", "are ads bad for the economy", "are ads good for the environment",
        "will ai take over", "can i eat a turtle", "what do people taste like", "how did the earth get here", "how did everyone get here", "how did there ever end up being",
        "how to use up all my lemons", "is sushi cultural appropriation", "how to send an email", "will email still exist in ten years", "how do refrigerators work", "can i ask someone if they are ok",
        "how to market to teenagers", "how to market to baby boomers", "how to market to younger generations", "why are babies so ugly", "why are babies so stupid", "how to get stain off wall", "red stain on carpet",
        "is my cat plotting to kill me", "what happens when you die", "is yelling abuse", "is the universe a simulation", "will i ever get to retire", "fickle meaning", "salmon dance", "gay statistics",
        "bird flu", "infinity tattoo meaning", "why are my hands wet", "protonopia colourblindness", "social anxiety", "dog bark different languages", "flying fish", "are flying fish real",
        "do flying fish actually fly", "low hairline no forehead", "is my forehead too big", "how to do makeup", "how to get rid of ants", "painful ear popping when swallowing", "can we make piles in your yard",
        "how to get my neighbour to move away", "is there a stage 5 cancer", "laser lotus", "millennial traits", "over the counter sleeping pills", "how to get tired now", "gigabit vs gigabyte",
        "electric toothbrush vs manual toothbrush", "cashews vs peanuts", "what if i am allergic to peanuts", "double boiling", "am i gay", "how to come out as gay", "alcoholics anonymous", "rehab"
        
    };
}
