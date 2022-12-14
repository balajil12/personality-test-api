using personality_test_api.Db.Connections;
using personality_test_api.Models.Entities;

namespace personality_test_api.Util
{
    public static class DataFixture
    {
        public static void Initialize( this AppDb db)
        {
            if (!db.Tests.Any())
            {
                db.Tests.Add(new Test()
                {
                    Name = "An introvert or an extrovert?",
                    Description = "Are you an introvert or an extrovert?",
                    Questions = new Question[]
                    {
                        new Question()
                        {
                            Description = "You’re really busy at work and a colleague is telling you their life story and personal woes.",
                            Options = new QuestionOption[]
                            {
                                new QuestionOption(){ OptionText = "Don’t dare to interrupt them", Ratio = 1},
                                new QuestionOption(){ OptionText = "Think it’s more important to give them some of your time; work can wait", Ratio = 0.66f},
                                new QuestionOption(){ OptionText = "Listen, but with only with half an ear", Ratio = 0.33f},
                                new QuestionOption(){ OptionText = "Interrupt and explain that you are really busy at the moment", Ratio = 0},
                            }
                        },
                        new Question()
                        {
                            Description = "You’ve been sitting in the doctor’s waiting room for more than 25 minutes.",
                            Options = new QuestionOption[]
                            {
                                new QuestionOption(){ OptionText = "Look at your watch every two minutes", Ratio = 1},
                                new QuestionOption(){ OptionText = "Bubble with inner anger, but keep quiet", Ratio = 0.66f},
                                new QuestionOption(){ OptionText = "Explain to other equally impatient people in the room that the doctor is always running late", Ratio = 0.33f},
                                new QuestionOption(){ OptionText = "Complain in a loud voice, while tapping your foot impatiently", Ratio = 0},
                            }
                        },
                        new Question()
                        {
                            Description = "You’re having an animated discussion with a colleague regarding a project that you’re in charge of.",
                            Options = new QuestionOption[]
                            {
                                new QuestionOption(){ OptionText = "Don’t dare contradict them", Ratio = 1},
                                new QuestionOption(){ OptionText = "Think that they are obviously right", Ratio = 0.66f},
                                new QuestionOption(){ OptionText = "Defend your own point of view, tooth and nail", Ratio = 0.33f},
                                new QuestionOption(){ OptionText = "Continuously interrupt your colleague", Ratio = 0},
                            }
                        },
                        new Question()
                        {
                            Description = "You are taking part in a guided tour of a museum.",
                            Options = new QuestionOption[]
                            {
                                new QuestionOption(){ OptionText = "Are a bit too far towards the back so don’t really hear what the guide is saying", Ratio = 1},
                                new QuestionOption(){ OptionText = "Follow the group without question", Ratio = 0.66f},
                                new QuestionOption(){ OptionText = "Make sure that everyone is able to hear properly", Ratio = 0.33f},
                                new QuestionOption(){ OptionText = "Are right up the front, adding your own comments in a loud voice", Ratio = 0},
                            }
                        },
                        new Question()
                        {
                            Description = "During dinner parties at your home, you have a hard time with people who",
                            Options = new QuestionOption[]
                            {
                                new QuestionOption(){ OptionText = "Ask you to tell a story in front of everyone else", Ratio = 1},
                                new QuestionOption(){ OptionText = "Talk privately between themselves", Ratio = 0.66f},
                                new QuestionOption(){ OptionText = "Hang around you all evening", Ratio = 0.33f},
                                new QuestionOption(){ OptionText = "Always drag the conversation back to themselves", Ratio = 0},
                            }
                        }
                    },
                    Results = new TestResult[]
                    {
                        new TestResult()
                        {
                            Conclusion = "You are more of an introvert",
                            Description = "You feel that living alone is to live happily, and you prefer hiding in a crowd rather than standing out in one.......",
                            LessThanEqual = 0.25f,
                        },
                        new TestResult()
                        {
                            Conclusion = "You are more of a public introvert and private extrovert",
                            Description = "Within your circle of family and friends, you are completely at ease and it’s often you who takes the lead to organise outings, dinners, vacations, etc.......",
                            LessThanEqual = 0.5f,
                        },
                        new TestResult()
                        {
                            Conclusion = "You are more of a public extrovert and private introvert",
                            Description = "In public and at work you are a ball of energy perpetually on the move. You take the initiative, encourage others, hate waiting and are endlessly anticipating what’s going on around you.......",
                            LessThanEqual = 0.75f,
                        },
                        new TestResult()
                        {
                            Conclusion = "You are more of an extrovert",
                            Description = "Whether at work or at home, you are a leader, the head of the pack. You are the type of person who is at ease with everyone — with the grocer, the doctor, a managing director or a waiter.......",
                            LessThanEqual = 1f,
                        }
                    }
                });

                db.SaveChanges();
            }
        }
    }
}
