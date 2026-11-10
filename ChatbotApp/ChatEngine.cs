using System;
using System.Collections.Generic;

namespace ChatbotApp
{
    public class ChatEngine
    {
        // Step 2: Fields (Page 5)
        private string userName = "";
        private string favouriteTopic = "";
        private string lastTopic = "";
        private Random rng = new Random();

        // Memory for the Task Assistant
        private List<string> savedTasks = new List<string>();
        // Memory for the Quiz Game
        private bool quizActive = false;
        // Memory for the Activity Log
        private List<string> activityLog = new List<string>();
        private int currentQuestionIndex = 0;
        private int quizScore = 0;
        private bool isWaitingForTaskDetails = false;

        // Step 3: Keyword Data (Page 6)
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();

        // Step 4: Sentiment Words (Page 7)
        private List<string> worriedWords = new List<string>();

        // We put a tiny bit of data here so it works for you right now
        public ChatEngine()
        {
            // TODO: You should add more of your own here later!
            keywordResponses["password"] = new List<string> {
            "A password is a secret string of characters used to verify your identity. To stay protected: 1. Make it long (at least 12 characters)." +
            " 2. Use a mix of uppercase, lowercase, numbers, and symbols. 3. Never reuse the same password across different websites!",
            "To protect your passwords, consider using a Password Manager. Also, always enable Two-Factor Authentication (2FA) wherever possible." +
            " This means even if a hacker gets your password, they still can't get in without your phone!",
            "Never share your password with anyone, and avoid typing it on public Wi-Fi networks. If a website asks for your password via email, it is a scam!"
};
            keywordResponses["phishing"] = new List<string> {
            "Phishing is a cyberattack where criminals pretend to be a trusted company to steal your data. Protect yourself by checking the sender's email address" +
            " carefully and never clicking on suspicious links.",
            "To protect against phishing: Hover over links before you click them to see where they actually go. Look out for urgent language like 'Your account will" +
            " be closed!' and always type the website URL directly into your browser instead of clicking email links."
              };

            keywordResponses["malware"] = new List<string> { "Malware is malicious software. Keep your antivirus updated!", "Do not download files from untrusted" +
                " websites to avoid malware." };
            keywordResponses["wifi"] = new List<string> { "Avoid using public Wi-Fi for banking. Use a VPN for protection.", "Always use a strong password for" +
                " your home Wi-Fi network." };
            worriedWords.AddRange(new[] { "worried", "scared", "nervous" });
        }

        public string GetResponse(string input)
        {
            string question = input.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(question))
            {
                return "Please type a message.";
            }

            // 1. Check for Greetings
            if (question == "hello" || question == "hi" || question == "hey")
            {
                if (string.IsNullOrEmpty(userName))
                {
                    return "Greetings! I am your Cybersecurity Assistant. How can I help you today? Also, may I ask what your name is?";
                }
                return "Greetings, " + userName + "! How can I assist you with your cybersecurity questions today?";
            }

            // 2. Check for the user's name
            if (question.Contains("my name is "))
            {
                userName = input.Substring(question.IndexOf("my name is ") + 11).Trim();
                userName = char.ToUpper(userName[0]) + userName.Substring(1);
                return "It is a pleasure to meet you, " + userName + ". How may I assist you with your cybersecurity needs today?";
            }

            // 3. Check for Thank You / Goodbye
            if (question.Contains("thank you") || question.Contains("thanks") || question.Contains("bye"))
            {
                string nameToUse = string.IsNullOrEmpty(userName) ? "" : ", " + userName;
                return "You are very welcome" + nameToUse + ". If you have any further questions, please do not hesitate to ask. Have a safe and secure day!";
            }

            // --- QUIZ GAME LOGIC (10 QUESTIONS) ---

            if (question == "start quiz" || question.Contains("play quiz") || question.Contains("start game"))
            {
                quizActive = true;
                currentQuestionIndex = 0;
                quizScore = 0;
                activityLog.Add("Started a cybersecurity quiz");
                return "Welcome to the Cybersecurity Quiz! Question 1: What is the most common password used? A) 123456 B) Password123 C) Admin D) Qwerty";
            }

            if (quizActive)
            {
                if (currentQuestionIndex == 0)
                {
                    if (question == "a" || question.Contains("123456")) quizScore++;
                    currentQuestionIndex++;
                    return "Question 2: True or False: You should use the same password for all your accounts. (Type True or False)";
                }
                else if (currentQuestionIndex == 1)
                {
                    if (question == "false" || question == "f") quizScore++;
                    currentQuestionIndex++;
                    return "Question 3: What does 2FA stand for? A) Two-Factor Authentication B) Two-Fast Access C) Total File Archive";
                }
                else if (currentQuestionIndex == 2)
                {
                    if (question == "a" || question.Contains("two-factor")) quizScore++;
                    currentQuestionIndex++;
                    return "Question 4: What is phishing? A) Catching fish B) A cyberattack to steal data C) A type of antivirus";
                }
                else if (currentQuestionIndex == 3)
                {
                    if (question == "b" || question.Contains("cyberattack")) quizScore++;
                    currentQuestionIndex++;
                    return "Question 5: True or False: Public Wi-Fi is always secure. (Type True or False)";
                }
                else if (currentQuestionIndex == 4)
                {
                    if (question == "false" || question == "f") quizScore++;
                    currentQuestionIndex++;
                    return "Question 6: What should you do if you get a suspicious email? A) Reply B) Click the link C) Report it as phishing";
                }
                else if (currentQuestionIndex == 5)
                {
                    if (question == "c" || question.Contains("report")) quizScore++;
                    currentQuestionIndex++;
                    return "Question 7: What is malware? A) Malicious software B) A bad email C) Hardware";
                }
                else if (currentQuestionIndex == 6)
                {
                    if (question == "a" || question.Contains("malicious")) quizScore++;
                    currentQuestionIndex++;
                    return "Question 8: True or False: Antivirus software protects against all cyber threats. (Type True or False)";
                }
                else if (currentQuestionIndex == 7)
                {
                    if (question == "false" || question == "f") quizScore++;
                    currentQuestionIndex++;
                    return "Question 9: What is a VPN used for? A) Playing games B) Securing your internet connection C) Faster downloads";
                }
                else if (currentQuestionIndex == 8)
                {
                    if (question == "b" || question.Contains("securing")) quizScore++;
                    currentQuestionIndex++;
                    return "Question 10: True or False: You should click links from unknown senders. (Type True or False)";
                }
                else if (currentQuestionIndex == 9)
                {
                    if (question == "false" || question == "f") quizScore++;

                    quizActive = false;
                    string finalMessage = "Quiz Complete! Your score is " + quizScore + " out of 10. ";
                    if (quizScore >= 8) finalMessage += "Great job! You're a cybersecurity pro!";
                    else finalMessage += "Keep learning to stay safe online!";
                    return finalMessage;
                }
            }
            // --- END QUIZ LOGIC ---


            // --- NEW TASK ASSISTANT LOGIC STARTS HERE ---
            if (isWaitingForTaskDetails)
            {
                savedTasks.Add(input);
                isWaitingForTaskDetails = false;
                return "Got it! I have added '" + input + "' to your cybersecurity task list. You can ask me to 'show tasks' at any time.";
            }

            if (question.Contains("add task") || question.Contains("add a task") || question.Contains("remind me") || question.Contains("new task"))
            {
                if (question.Length > 15)
                {
                    savedTasks.Add(input);
                    activityLog.Add("Task added: " + input);
                    return "Task added! I have saved: '" + input + "' to your list.";
                }
                else
                {
                    isWaitingForTaskDetails = true;
                    return "Sure! What is the cybersecurity task you would like to add?";
                }
            }

            if (question.Contains("show task") || question.Contains("view task"))
            {
                if (savedTasks.Count == 0)
                {
                    return "You have no tasks saved right now. Try saying 'Add task' to create one.";
                }

                string taskList = "Here are your current cybersecurity tasks:\n";
                for (int i = 0; i < savedTasks.Count; i++)
                {
                    taskList += (i + 1) + ". " + savedTasks[i] + "\n";
                }
                return taskList;
            }
            
            // --- ACTIVITY LOG LOGIC ---
            if (question.Contains("show activity") || question.Contains("what have you done"))
            {
                if (activityLog.Count == 0)
                {
                    return "I haven't done anything yet! Try adding a task or starting a quiz.";
                }

                string logString = "Here is a summary of recent actions:\n";
                // Show only the last 5 actions to keep it neat
                int startIndex = Math.Max(0, activityLog.Count - 5);
                for (int i = startIndex; i < activityLog.Count; i++)
                {
                    logString += "- " + activityLog[i] + "\n";
                }
                return logString;
            }
            // --- END ACTIVITY LOG LOGIC ---
            // 4. Sentiment check
            foreach (string word in worriedWords)
            {
                if (question.Contains(word))
                {
                    return "It sounds like you are feeling " + word + ". Please do not worry, cybersecurity can be complex. How can I help you feel safer?";
                }
            }

            // 5. Keyword check
            foreach (var keyword in keywordResponses.Keys)
            {
                if (question.Contains(keyword))
                {
                    lastTopic = keyword;
                    return keywordResponses[keyword][rng.Next(keywordResponses[keyword].Count)];
                }
            }

            // 6. Follow-up check
            if (question.Contains("tell me more") || question.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    return "Certainly. Regarding " + lastTopic + ", the best practice is to always stay vigilant and keep your software updated.";
                }
                else
                {
                    return "What specific topic would you like me to elaborate on?";
                }
            }

            // 7. Fallback
            return "I apologize, but I do not quite understand. Could you please rephrase your question, or ask me about passwords or phishing?";
        }


        // Step 7: Capture Info (Page 11)
        private void CaptureUserInfo(string input)
        {
            // TODO: detect and store things like favouriteTopic
        }
    }
}
