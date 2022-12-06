using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using static LearnMate.backend;
using System.Xml.Linq;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Drawing;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.Security.AccessControl;
using System.Diagnostics.Metrics;
using Microsoft.VisualBasic.ApplicationServices;
using static LearnMate.backend.School;

namespace LearnMate
{
    public class backend
    {
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        private static extern int AllocConsole();


        public static string errorReason;
        public static string diagnosis;
        public static string message;
        public static bool verified;
        public static DateTime currentWeekCommencing; //=get the date of the current week commencing

        public static int currentUserID = 0;
        public static string currentUserName;
        public static string currentUserType;
        public static string currentName;
        public static string currentSchoolName;
        public static int currentSchoolID;

        public static List<User> Users = new List<User>(); //load all pre-existing Users into this list.

        public static List<School> Schools = new List<School>(); //load all pre-existing Schools into this list.

        public static List<Subject> Subjects = new List<Subject>();

        //once json is made, remove the createQuestionSets process in backend constructor.


        //testing login functionality with a test teacher.

        //backend constructor. serialise all pre-existing data from JSON to the corresponding objects.
        public backend()
        {
            ////THE FOLLOWING LOADS ALL JSON CONTENT INTO THE LISTS SHOWN ABOVE UPON FIRST CALL.
            AllocConsole();

            backend.Subject maths = new backend.Subject("Mathematics"); //maths subject information is created
            backend.Subject physics = new backend.Subject("Physics"); //same for other subjects
            backend.Subject compsci = new backend.Subject("Computer Science");

            Student student = new Student("User1", "Pass", "Kevin"); //student object created
            student.SubjectsEnrolledTo.Add("Maths"); //student instance is now enrolled in maths.



            Teacher testTeacher = new Teacher("Username", "Password", "Tye");
            Student student2 = new Student("User2", "Pass", "James");
            Student student3 = new Student("User3", "Pass", "Jacob");
            Student student4 = new Student("User4", "Password", "Paul");
            Student student5 = new Student("User5", "Pass", "Queen");
            Student student6 = new Student("User6", "Pass", "Henry");
            Student student7 = new Student("User7", "Pass", "Martha");
            Student student8 = new Student("User8", "Pass", "Tina");
            Student student9 = new Student("User9", "Pass", "Isaac");
            HomeLearner testHL = new HomeLearner("User10", "Pass", "Mac");

            School school = new School("TyesSchool", "abc");

            school.addClass("TyesFirstClass"); //automatically adds to classesInSchool.
            school.addClass("12F");
            school.addClass("13E");


            school.addStudentToClass(student, school.getClassIDByClassName("TyesFirstClass"));  //adds a student to a class, now assigned
            school.addStudentToClass(student2, school.getClassIDByClassName("TyesFirstClass"));
            school.addStudentToClass(student3, school.getClassIDByClassName("TyesFirstClass"));
            school.addStudentToClass(student4, school.getClassIDByClassName("TyesFirstClass"));
            school.addStudentToClass(student5, school.getClassIDByClassName("TyesFirstClass"));
            school.addStudentToClass(student8, school.getClassIDByClassName("12F"));
            school.addStudentToClass(student9, school.getClassIDByClassName("13E"));
            school.addStudentToClass(student7, school.getClassIDByClassName("13E"));
            school.addUnassignedStudent(student6);

            school.removeUnassignedStudentByObject(student5); //need to be removed from the unassigned students to maintain data consistency.
            school.removeUnassignedStudentByObject(student4);
            school.removeUnassignedStudentByObject(student3);
            school.removeUnassignedStudentByObject(student2);
            school.removeUnassignedStudentByObject(student);
            school.removeUnassignedStudentByObject(student8);
            school.removeUnassignedStudentByObject(student9);

            testTeacher.addToSchool(school.schoolID);

            //
            //declare class object to access and modify properties



            ////for each teacher object in the JSON,
            //Teachers.Add(); //load all pre-existing teachers into list 
            ////do the same with the other object lists
            //Users.Add();
            //Schools.Add();
            //Students.Add();
            //Classes.Add();
            //AND LOAD UP PRACTICE QUESTIONS FROM JSON. in the meantime, pre-define question sets as shown below.

        }

        public void saveAllUsers()
        {
            //string serialisedResult = JsonConvert.SerializeObject(Users);
            //string testResult = JsonConvert.SerializeObject(backend.Users);
            //wipe all current info in JSON, deserialise all data into JSON file. (if we simply added to json file, it wouldn't account for removal of objects)
        }

        //public string fileName = //find how to reference a local file.


        //A new Subject contains name, SubjectTopics list and a subjectID, SubjectTopics contains subTopics list, name, ID  which contain microSessions list which contains (topic questions and a video path).
        public class Subject //ALL SUBJECT INFORMATION WILL BE LOADED IN ONCE JSON IS SET UP (make sure this state is working perfectly first). ONCE DONE, JUST SET CONSTRUCTOR TO LOAD WHATS IN JSON.
        {
            public string SubjectName;
            public List<Topic> SubjectTopics = new List<Topic>();
            public int subjectID;

            public Subject(string subjectName) //CONSTRUCTOR: fill in all topic info 
            {
                SubjectName = subjectName;
                subjectID= Subjects.Count + 1;

                if (subjectName == "Mathematics")
                {
                    //MICROSESSIONS
                    microSession mc = new microSession(); //for maths pure - differentiation and integration
                    mc.name = "Differentiation Basics";
                    microSession mc2 = new microSession();
                    mc2.name = "Integration Basics";
                    microSession mc3 = new microSession(); //for maths mechanics
                    microSession mc4 = new microSession(); 
                    microSession mc5 = new microSession(); //for maths stats
                    microSession mc6 = new microSession(); 

                    //TOPIC QUESTIONS IN EACH MICROSESSION
                    TopicQuestion tc = new TopicQuestion("Differentiate cos(x)", "-sin(x)");
                    mc.addTopicQuestion(tc);
                    TopicQuestion tc2 = new TopicQuestion("What is differentiation?", "Rate of change");
                    mc.addTopicQuestion(tc2);
                    mc.videoPath = ""; //differentiation video


                    TopicQuestion tc3 = new TopicQuestion("What is meant by integration?", "Area under curve");
                    mc2.addTopicQuestion(tc3);
                    TopicQuestion tc4 = new TopicQuestion("Integrate sin(x).", "-cos(x)");
                    mc2.addTopicQuestion(tc4);
                    mc2.videoPath = ""; //integration video

                    //MECHANICS
                    TopicQuestion tc5 = new TopicQuestion("MechanicsQ1", "Answer");
                    mc3.addTopicQuestion(tc5);
                    TopicQuestion tc6 = new TopicQuestion("MechanicsQ2", "mathsA4");
                    mc3.addTopicQuestion(tc6);
                    mc3.videoPath = "";

                    TopicQuestion tc7 = new TopicQuestion("MechanicsQ3", "mathsA3");
                    mc4.addTopicQuestion(tc7);
                    TopicQuestion tc8 = new TopicQuestion("MechanicsQ4", "mathsA4");
                    mc4.addTopicQuestion(tc8);
                    mc4.videoPath = "";

                    //STATS (ew)
                    TopicQuestion tc9 = new TopicQuestion("If the test statistic is within the critical region, what do we do to H 0?", "Reject");
                    mc5.addTopicQuestion(tc9);
                    TopicQuestion tc10 = new TopicQuestion("StatisticsQ2", "mathsA4");
                    mc5.addTopicQuestion(tc10);
                    mc5.videoPath = "";

                    TopicQuestion tc11 = new TopicQuestion("StatisticsQ3", "mathsA3");
                    mc6.addTopicQuestion(tc11);
                    TopicQuestion tc12 = new TopicQuestion("StatisticsQ4", "mathsA4");
                    mc6.addTopicQuestion(tc12);
                    mc6.videoPath = "";
                    
                    
                    //SUBTOPICS
                    subTopic st = new subTopic(); //maths pure
                    subTopic st2 = new subTopic(); //maths mechanics
                    subTopic st3 = new subTopic(); //maths statistics

                    st.SubTopicName = "Differentiation and Integration";
                    st.addMicroSession(mc); //add multiple microsessions
                    st.addMicroSession(mc2);

                    st2.SubTopicName = "Projectile Motion";
                    st2.addMicroSession(mc3);
                    st2.addMicroSession(mc4);

                    st3.SubTopicName = "Hypothesis Testing";
                    st3.addMicroSession(mc5);
                    st3.addMicroSession(mc6);

                    //TOPICS
                    Topic topic = new Topic();
                    Topic topic2 = new Topic();
                    Topic topic3 = new Topic();

                    topic.topicID = 1;
                    topic2.topicID = 2;
                    topic3.topicID = 3;
                    topic.TopicName = "Pure";
                    topic.addSubtopic(st);
                    topic2.TopicName = "Mechanics";
                    topic2.addSubtopic(st2);
                    topic3.TopicName = ("Statistics");
                    topic3.addSubtopic(st3);

                    SubjectTopics.Add(topic);
                    SubjectTopics.Add(topic2);
                    SubjectTopics.Add(topic3);
                }
                else if (subjectName == "Physics")
                {
                    microSession mc = new microSession(); //for statics - moments
                    microSession mc2 = new microSession(); //for statics - scalars and vectors
                    microSession mc3 = new microSession(); //for further mechanics - circular motion
                    microSession mc4 = new microSession(); //for further mechanics - simple harmonic motion
                    microSession mc5 = new microSession(); //for thermal physics - the gas laws
                    microSession mc6 = new microSession(); //for thermal physics - kinetic theory

                    TopicQuestion tc = new TopicQuestion("What is the resultant moment for an object in equilibrium?", "Zero.");
                    mc.addTopicQuestion(tc);
                    TopicQuestion tc2 = new TopicQuestion("What is a moment?", "Turning effect");
                    mc.addTopicQuestion(tc2);
                    mc.videoPath = "";
                    
                    TopicQuestion tc3 = new TopicQuestion("What is meant by a scalar quantity?", "Such with magnitude only.");
                    mc2.addTopicQuestion(tc3);
                    TopicQuestion tc4 = new TopicQuestion("Name the vector quantity of speed.", "Velocity");
                    mc2.addTopicQuestion(tc4);
                    mc2.videoPath = "";

                    TopicQuestion tc5 = new TopicQuestion("Where is acceleration acting for an object in circular motion?", "Center");
                    mc3.addTopicQuestion(tc5);
                    TopicQuestion tc6 = new TopicQuestion("What trajectory would an object go if it were released during orbit?", "Line");
                    mc3.addTopicQuestion(tc6);
                    mc3.videoPath = "";

                    TopicQuestion tc7 = new TopicQuestion("State the conditions required for simple harmonic motion.", "Acceleration proportional to displacement.");
                    mc4.addTopicQuestion(tc7);
                    TopicQuestion tc8 = new TopicQuestion("Where is acceleration at its maximum?", "Amplitude");
                    mc4.addTopicQuestion(tc8);
                    mc4.videoPath = "";

                    TopicQuestion tc9 = new TopicQuestion("What law does an ideal gas follow?", "Boyle");
                    mc5.addTopicQuestion(tc9);
                    TopicQuestion tc10 = new TopicQuestion("GasQ2", "Ans");
                    mc5.addTopicQuestion(tc10);
                    mc5.videoPath = "";

                    TopicQuestion tc11 = new TopicQuestion("State the acronym you're recommended to remember regarding assumptions about the kinetic theory model.", "RAVED");
                    mc6.addTopicQuestion(tc11);
                    TopicQuestion tc12 = new TopicQuestion("What does 'E' in the acronym stand for?", "Elastic");
                    mc6.addTopicQuestion(tc12);
                    mc6.videoPath = "";

                    subTopic st = new subTopic();
                    subTopic st2 = new subTopic();
                    subTopic st3 = new subTopic();

                    st.SubTopicName = "Statics";
                    st.addMicroSession(mc); //add multiple microsessions
                    st.addMicroSession(mc2);

                    st2.SubTopicName = "Circular and Simple Harmonic Motion";
                    st2.addMicroSession(mc3);
                    st2.addMicroSession(mc4);

                    st3.SubTopicName = "Gas laws and Kinetic theory";
                    st3.addMicroSession(mc5);
                    st3.addMicroSession(mc6);

                    Topic topic = new Topic();
                    Topic topic2 = new Topic();
                    Topic topic3 = new Topic();
                    Topic topic4 = new Topic();
                    Topic topic5 = new Topic();
                    Topic topic6 = new Topic();

                    topic.TopicName = "Dynamics";
                    topic.addSubtopic(st);
                    topic2.TopicName = "Further Mechanics";
                    topic2.addSubtopic(st2);
                    topic3.TopicName = ("Thermal Physics");
                    topic3.addSubtopic(st3);
                    topic4.TopicName = ("Waves");
                    topic5.TopicName = ("Electricity");
                    topic6.TopicName = ("Thermal Physics");

                    SubjectTopics.Add(topic);
                    SubjectTopics.Add(topic2);
                    SubjectTopics.Add(topic3);
                }
                else if (subjectName == "Computer Science")
                {
                    microSession mc = new microSession(); //for contemp. processors - vonn neuman and harvard architecture
                    microSession mc3 = new microSession(); //for Data strucures - data types and boolearn algebra
                    microSession mc4 = new microSession(); 

                    TopicQuestion tc = new TopicQuestion("HarvardQ", "Ans");
                    mc.addTopicQuestion(tc);
                    TopicQuestion tc2 = new TopicQuestion("VonnQ", "Ans");
                    mc.addTopicQuestion(tc2);
                    mc.videoPath = "";

                    TopicQuestion tc5 = new TopicQuestion("DataTypesQ", "Ans");
                    mc3.addTopicQuestion(tc5);
                    TopicQuestion tc6 = new TopicQuestion("DataTypesQ2", "Ans");
                    mc3.addTopicQuestion(tc6);
                    mc3.videoPath = "";

                    TopicQuestion tc7 = new TopicQuestion("BooleanQ.", "Ans");
                    mc4.addTopicQuestion(tc7);
                    TopicQuestion tc8 = new TopicQuestion("BooleanQ2", "Ans");
                    mc4.addTopicQuestion(tc8);
                    mc4.videoPath = "";


                    subTopic st = new subTopic();
                    subTopic st2 = new subTopic();

                    st.SubTopicName = "Harvard Architecture";
                    st.addMicroSession(mc); //add multiple microsessions

                    st2.SubTopicName = "Data Types and Boolean Algebra";
                    st2.addMicroSession(mc3);
                    st2.addMicroSession(mc4);


                    Topic topic = new Topic();
                    Topic topic2 = new Topic();


                    topic.TopicName = "Contemporary Processors";
                    topic.addSubtopic(st);
                    topic2.TopicName = "Data Structures";
                    topic2.addSubtopic(st2);

                    SubjectTopics.Add(topic);
                    SubjectTopics.Add(topic2);
                }
                Subjects.Add(this);
            }

            public int getTopicIDByName(string topicName)
            {
                int index = -1;
                for (int i = SubjectTopics.Count - 1; i >= 0; i--)
                {
                    if (SubjectTopics[i].TopicName == topicName)
                    {
                        index = i + 1;
                    }
                }
                return index;
            }

            public int getSubTopicIDByName(string subTopicName,int TopicID)
            {
                int index = -1;
                for (int i = SubjectTopics[TopicID-1].subTopics.Count - 1; i >= 0; i--)
                {
                    if (SubjectTopics[TopicID - 1].subTopics[i].SubTopicName == subTopicName)
                    {
                        index = i + 1;
                    }
                }
                return index;
            }
        }

        public int getSubjectIDBySubjectName(string subjectName)
        {
            int index = -1;
            for (int i = Subjects.Count - 1; i >= 0; i--)
            {
                if (Subjects[i].SubjectName == subjectName)
                {
                    index = i + 1;
                }
            }
            return index;
        }

        public class Topic
        {
            public string TopicName;
            public List<subTopic> subTopics = new List<subTopic>();
            public int topicID;

            public void addSubtopic(subTopic st)
            {
                subTopics.Add(st);
            }
        }

        public class subTopic
        {
            public string SubTopicName;
            public int subtopicID;
            public List<microSession> microSessions = new List<microSession>();

            public void addMicroSession(microSession mc)
            {
                microSessions.Add(mc);
            }
        }

        public class microSession
        {
            public string name;
            public string videoPath;
            public List<TopicQuestion> TopicQuestions = new List<TopicQuestion>(); //then traverse through questions.

            public void addTopicQuestion(TopicQuestion topicQuestion)
            {
                TopicQuestions.Add(topicQuestion);
            }
        }
        //all that matters is the microsessions.
        //have a list of microsessions in a subtopic.
        //create the subTopic, st.microsessions
        public class TopicQuestion
        {
            public int topicQuestionID;
            public string Question;
            public string Answer;

            public TopicQuestion(string q, string a)
            {
                Question = q;
                Answer = a;
            }
        }


        





        public class User
        {
            //stores the attributes about a User object.
            public string Username;
            public string Name;
            public string Password;
            public string UserType;
            public string note;
            public int userID; //usercode acts as the primary key for each user.
            public bool banned;
            public List<string> SubjectsEnrolledTo = new List<string>();
            public List<Event> Events = new List<Event>();
            public bool loggedIn;
            
            public void addSelectedSubjectsByName(string subjectName)
            {
                SubjectsEnrolledTo.Add(subjectName);
            }
            
            public void addEvent(Event eventObject)
            {
                Events.Add(eventObject);
            }
            //creates a new user with user attributes
            public User(string _Username, string _Password, string _Name, string _userType) //THIS DOES NOT GET CALLED...
            {
                //if the user belongs to a school, School.addUser(UserCode, institutionCode)
                //else
                Username = _Username;
                Password = _Password;
                Name = _Name;
                UserType = _userType;
            } //CREATES A NEW USER

            public User()
            {
                //since I don't explicitly invoke a call to the Users constructor when creating a User-derived object, it essentially calls a parameterless function from Users. therefore, this constructor is needed
            } //CREATES A NEW USER THATS A MEMBER OF A SCHOOL
        }

        public class Event
        {
            public int eventID;
            public string eventType;
            public string EventName;
            public string EventDescription;
            public DateTime startTime;
            public DateTime endTime;
            public DateTime eventDate;
        }
        //stores the attributes about a School object.
        public class School //to save, list of schools only.
        {
            public string InstitutionCode; //primary key
            public int schoolID;
            public string SchoolName;
            public List<Class> classesInSchool = new List<Class>(); //has members can be retrieved by traversing through the classes.
            //we want below to be added to 'classesInSchool' asap, to remove the need of having to update everywhere after every modification of an attribute.
            public List<Student> unassignedStudents = new List<Student>();
            public List<Teacher> unassignedTeachers = new List<Teacher>();
            public School(string schName, string insCode)
            {
                SchoolName = schName;
                InstitutionCode = insCode;
                schoolID = Schools.Count + 1;
                Schools.Add(this);
                
                Console.WriteLine("New school " + schName + " created with institution code " + insCode + ", schoolID " + schoolID + ". Is without teachers, students or classes.");
            } //NEW SCHOOL WITHOUT TEACHERS, STUDENTS OR CLASSES

            public void replaceInSchoolsList() //any change to a school is copied to the list of schools.
            {
                Schools[schoolID - 1] = this;
            }

            public Class getClassObjectByClassID(int classID)
            {
                return (classesInSchool[classID - 1]);
            }
            public void removeUnassignedStudentByID(int userID)
            {
                for (int i = unassignedStudents.Count - 1; i >= 0; i--)
                {
                    if (unassignedStudents[i].userID == userID)
                    {
                        unassignedStudents.RemoveAt(i);
                        replaceInSchoolsList();
                    }
                }
            }

            public void removeUnassignedTeacherByID(int userID)
            {
                for (int i = unassignedTeachers.Count - 1; i >= 0; i--)
                {
                    if (unassignedTeachers[i].userID == userID)
                    {
                        unassignedTeachers.RemoveAt(i);
                        replaceInSchoolsList();
                    }
                }
            }

            public void removeUnassignedTeacherByObject(Teacher teacher)
            {
                for (int i = unassignedTeachers.Count - 1; i >= 0; i--)
                {
                    if (unassignedTeachers[i] == teacher)
                    {
                        unassignedTeachers.RemoveAt(i);
                        replaceInSchoolsList();
                    }
                }
            }

            public void removeUnassignedStudentByObject(Student student)
            {
                for (int i = unassignedStudents.Count - 1; i >= 0; i--)
                {
                    if (unassignedStudents[i] == student)
                    {
                        unassignedStudents.RemoveAt(i);
                        replaceInSchoolsList();
                    }
                }
            }

            public void addStudentToClass(Student student, int classID)
            {
                classesInSchool[classID - 1].Students.Add(student);
                //then when called, call removefromunassigned, replaceinstudentslist when done.
                for (int i = unassignedStudents.Count - 1; i >= 0; i--)
                {
                    if (unassignedStudents[i] == student)
                    {
                        unassignedStudents.RemoveAt(i);
                        replaceInSchoolsList();
                    }
                }
            }

            public void removeStudentFromClass(Student student, int classID)
            {
                classesInSchool[classID - 1].Students.Remove(student);
                unassignedStudents.Add(student);
                replaceInSchoolsList();
            }
            public void addClass(string className)
            {
                //add the class to classesinschool.
                Class _class = new Class(className);
                _class.classID = classesInSchool.Count + 1; //class is already added. say 3 classes, initiate the second, 
                classesInSchool.Add(_class);
                replaceInSchoolsList();
            }

            public int getClassIDByClassName(string className)
            {
                int classID=-1;
                for (int i = classesInSchool.Count - 1; i >= 0; i--)
                {
                    if (classesInSchool[i].className == className)
                    {
                        classID = i + 1;
                    }
                }
                return classID;
            }

            public string getClassNameByClassID(int classID)
            {
                string className = classesInSchool[classID - 1].className;
                return className;
            }
            public void addMainTeacherToClass(int userID, int classID)
            {
                User user = Users[userID - 1];
                Teacher teacher = (Teacher)user;
                classesInSchool[classID - 1].mainTeacher = teacher;
                replaceInSchoolsList();
            }

            void addAssistantTeacherToClass(int userID, int classIDfromthisschool)
            {
                User user = Users[userID - 1];
                Teacher teacher = (Teacher)user;
                classesInSchool[classIDfromthisschool - 1].assistantTeacher = teacher;
                replaceInSchoolsList();
            }

            public void addUnassignedTeacherByUserID(int userID) //adds a teacher or student object to unassignedMembers ready to be added to their classes.
            {
                Teacher teacher = (Teacher)Users[userID - 1];
                unassignedTeachers.Add(teacher);
                replaceInSchoolsList();
            }

            public void addUnassignedStudentByUserID(int userID) //adds a teacher or student object to unassignedMembers ready to be added to their classes.
            {
                Student student = (Student)Users[userID - 1];
                unassignedStudents.Add(student);
                replaceInSchoolsList();

            }

            public void addUnassignedStudent(Student student) //adds a teacher or student object to unassignedMembers ready to be added to their classes.
            {
                unassignedStudents.Add(student);
                replaceInSchoolsList();
            }

            public void removeUnassignedTeacherByUserID(int userID)
            {
                Teacher teacher = (Teacher)Users[userID - 1];
                unassignedTeachers.Remove(teacher);
                replaceInSchoolsList();
            }
            public void removeUnassignedStudentByUserID(int userID)
            {
                Student student = (Student)Users[userID - 1];
                unassignedStudents.Remove(student);
                replaceInSchoolsList();
            }
            void addToSchoolsList()
            {
                Schools.Add(this);
            }

            public void removeClass(int classID)
            {
                for (int j = classesInSchool[classID-1].Students.Count - 1; j >= 0; j--) //for every student in that class,
                {
                    classesInSchool[classID-1].Students[j].removeFromSchool(); //run the function that removes them from a school (sets schoolID to -1)
                }
                classesInSchool.Remove(classesInSchool[classID - 1]); //then remove the class from the list of classes in that school.
                replaceInSchoolsList();
                //then call setCurrentUser to see how the current user is affected by it.

            }

            public void removeSchool()
            {
                for (int i = classesInSchool.Count - 1; i >= 0; i--) //for every class in the school,
                {
                    for (int j = classesInSchool[i].Students.Count - 1; j >= 0; j--)  //for every student in each class,
                    {
                        classesInSchool[i].Students[j].removeFromSchool(); //run the function that removes a student from a school (sets schoolID to -1) this is all that matters
                        //then call setCurrentUser.
                    }
                }
                Schools.Remove(this); //if a school is removed, all its classes are removed.
                //then call setCurrentUser to see how the current user is affected by it.
            }

            //NEW
            public void createClassesBySubject(string subjectName, int maxNumberOfStudentsPerClass)
            {
                Class currentClass = new Class(subjectName+" 1"); //class variable
                classesInSchool.Add(currentClass);
                int numOfClassesCreated = 1;
                for (int i=unassignedStudents.Count; i >= 0; i--) //for every unassigned student,
                {
                    if (unassignedStudents[i - 1].SubjectsEnrolledTo.Contains(subjectName)) //if they're studying that subject,
                    {
                        if (currentClass.Students.Count <= maxNumberOfStudentsPerClass) //if the current class isn't full,
                        {
                            //fill student in then replace in classes list using the classID
                            currentClass.Students.Add(unassignedStudents[i - 1]); //maintain data consistency
                            removeUnassignedStudentByID(unassignedStudents[i - 1].userID); //maintain data consistency
                            classesInSchool[classesInSchool.IndexOf(currentClass)] = currentClass; 
                            //Finds the index of the current class and replaces the old version of the class with the new version (with the added student) 
                        }
                        if (currentClass.Students.Count == maxNumberOfStudentsPerClass) //if the max number of students,
                        {
                            numOfClassesCreated++; //increment the no of classes created
                            currentClass = new Class(subjectName + " " + Convert.ToString(numOfClassesCreated)); //add the name as 'Physics 1, Physics 2' etc...
                        }
                    }
                }
            }
        }


        public class HomeLearner : User
        {  
            public HomeLearner(string _Username, string _Password, string _Name)
            {
                Username = _Username;
                Password = _Password;
                Name = _Name;
                UserType = "Home Learner";

                userID = Users.Count+1;
                addToUsersList();
                Console.WriteLine("New Home Learner " + Name + " (" + Username + ") " + "created with userID "+userID);
            }

            public void replaceInUsersList()
            {
                Users[userID - 1] = this;
            }

            public void addToUsersList()
            {
                Users.Add(this);
            }
        }
        public class MemberOfSchool : User
        {
            public int schoolID;
        }

        //stores the attributes about a Teacher object.
        public class Teacher : MemberOfSchool
        {
            public List<int> TeachesClasses  = new List<int>(); //holds the classes a teacher teaches and NOTE THIS IS NOT MODIFIED BY THE CONSTRUCTOR.
            public List<string> TeachesSubjects = new List<string>();
            public Teacher(string _Username, string _Password, string _Name)
            {
                Username = _Username;
                Password = _Password;
                Name = _Name;
                UserType = "Teacher";
                //add this teacher to the list of teachers
                userID = Users.Count+1;
                addToUsersList();

                Console.WriteLine("New Teacher (and User) " + Name + " (" + Username + ") " + ", and userID " + userID + ", but without a schoolID.");

            } //NEW TEACHER WITHOUT A SCHOOLID

            public void removeFromSchool()
            {
                schoolID = -1;
                replaceInUsersList();
            }

            public void addToSchool(int _schoolID)
            {
                schoolID = _schoolID; //they now have a connection to the school
                Schools[schoolID - 1].unassignedTeachers.Add(this); 
                //a teacher will be entering the school as unassigned by default, ...
                //... as they have not been added to any classes yet.
                replaceInUsersList(); //maintaining data consistency
            }

            public void replaceInUsersList()
            {
                Users[userID - 1] = this; //updates in users list.
            }

            public void addToUsersList()
            {
                Users.Add(this);
            }
        }


        public class Student : MemberOfSchool //make sure a school has that student
        {
            public List<practiceModule>AssignmentModules = new List<practiceModule>();

            //Here is the option to add a Student without the classes they belong to.

            public Student(string _Username, string _Password, string _Name)
            {
                Username = _Username;
                Password = _Password;
                Name = _Name;
                UserType = "Student";
                userID = Users.Count + 1;
                addToUsersList();
                
                Console.WriteLine("New Student (and User) " + Name + " (" + Username + ") " + " with studentID "+ ", and userID " + userID + " is created, but is without a schoolID.");

            } //NEW STUDENT WITHOUT A SCHOOLID OR CLASSES BELONGING TO

            public void removeFromSchool()
            {
                schoolID = -1;
                replaceInUsersList();

            }

            public void addToSchool(int _schoolID)
            {
                schoolID = _schoolID;
                Schools[schoolID - 1].unassignedStudents.Add(this);
                replaceInUsersList();
            }
            public void replaceInUsersList()
            {
                Users[userID - 1] = this;
            }

            public void addToUsersList()
            {
                Users.Add(this);
            }
        }

        public class Class
        {
            public string className;
            public int classID; //only set by the school object.
            public List<Student> Students = new List<Student>();
            public Teacher mainTeacher;
            public Teacher assistantTeacher;

            public Class(string _className)
            {
                className = _className;
                //other properties will be modified by the school's methods.

            }
        }


        public class practiceModule
        {
            public string topicName;
            public practiceModule()
            {

            }
        }
        //searches through all user objects and removes if finds


        public int getUserID() //the username is passed here from either the login form's text box OR the signup form's text box. You'll need this for 
        {
            return currentUserID;
            Console.WriteLine("getUserID was called and returned " + currentUserID);
        }

        public int getSubjectIDByName(string subjectName)
        {
            int index = -1;
            for (int i = Subjects.Count - 1; i >= 0; i--)
            {
                if (Subjects[i].SubjectName == subjectName)
                {
                    index = i + 1;
                }
            }
            return index;
        }


        public int getUserIDWithUsername(string username)
        {
            int index = -1;
            for (int i = Users.Count - 1; i >= 0; i--)
            {
                if (Users[i].Username == username)
                {
                    index = i + 1;
                    return index;
                }
            }
            return index;
        }

        public string getUsernameWithUserID(int userID)
        {
            return (Users[userID - 1].Username);
        }
        public string getCurrentUserName() //the username is passed here from either the login form's text box OR the signup form's text box. You'll need this for 
        {
            return currentUserName;
            Console.WriteLine("getUserName was called and returned " + currentUserName);
        }

        public string getFirstName()
        {
            string[] separatedNames = currentName.Split(" ");
            return (separatedNames[0]);
            Console.WriteLine("getName was called and returned " + separatedNames[0]);
        }

        public string getUserType()
        {
                return currentUserType; 
            Console.WriteLine("getUserType was called and returned " + currentUserType);
        }

        public string checkUserType(int userID)
        {

            return(Users[userID - 1].UserType);

        }
        public bool login(string username, string password) //CHECKED AND SIMPLIFIED
        {
            Console.WriteLine("\nLogin was called...");
            bool value = false;
            int userID = getUserIDWithUsername(username); //returns -1 if user doesn't exist
            if (userID != -1) //if user does exist,
            {
                if (Users[userID].Password == password) //if the password entered matches,
                {
                    Console.WriteLine("User '" + username + "' matches with '" + Users[userID].Password + "', => Successful login.");

                    if (Users[userID - 1].loggedIn == true) //if they're not already logged in..
                    {
                        value = true; //return true for a successful login.
                        Users[userID-1].loggedIn = true;
                    }
                }
                else
                {
                    Console.WriteLine("'" + password + "' doesn't match with '" + Users[userID].Password + "'. => Unsuccessful login.");
                } //if it doesn't, keep the value at false 
            }
            else
            {
                Console.WriteLine("That user doesn't exist.");
            }
            return value; //and return the value.
        }

        public void logout()
        {
            //maybe lbllink isnt working due to logouts? 
        }
        public void changePassword(string username, string oldPass, string newPass)
        {
            int userID = getUserIDWithUsername(username); //gets their userID for faster retrieval
            if (userID != -1) //if the user exists (getuserID returns -1 if not found)
            {
                if (Users[userID - 1].Password == oldPass) //if their stored pass = oldpass
                {
                    Users[userID - 1].Password = newPass; //pass is replaced
                }
                else
                {
                    MessageBox.Show("Your old password is incorrect."); //if it doesn't its wrong.
                }
            }
            else
            {
                MessageBox.Show("That username doesn't exist.");
            }
        }
        public void setCurrentUserWithSchool(int userID, string insCode) //call if there are schools and if they entered an ins code.
        {
            Console.WriteLine("\nsetCurrentUser was called in backend...");

            currentUserID = Users[userID-1].userID;
            currentUserName = Users[userID-1].Username;
            currentUserType = Users[userID-1].UserType;
            currentName = Users[userID-1].Name;
            currentSchoolName = Schools[getSchoolID(insCode) - 1].SchoolName;
            currentSchoolID = Schools[getSchoolID(insCode) - 1].schoolID;

            Console.WriteLine("currentUserName set to " + currentUserName + ", currentUserID set to " + currentUserID + ", currentName set to " + currentName + ", \ncurrentUserType set to " + currentUserType+", currentSchoolID set to"+currentSchoolID+", currentSchoolName set to "+currentSchoolName);
        }

        public void setCurrentUser(int userID)
        {
            currentUserID = Users[userID - 1].userID; //the current user info is copied...
            currentUserName = Users[userID - 1].Username; //...from that of the logged in user's info
            currentUserType = Users[userID - 1].UserType;
            currentName = Users[userID - 1].Name;
            currentSchoolName = "NONE";
            currentSchoolID = -1;
            Console.WriteLine("currentUserName set to " + currentUserName + ", currentUserID set to " + currentUserID + ", currentName set to " + currentName + ", currentUserType set to " + currentUserType);
        }

        public bool checkAnySchoolExists()
        {
            bool value = false;
            if (Schools.Count >= 1)
            {
                value = true;
            }
            return value;
        }

        public bool checkASchoolexists(string insCode)
        {
            bool exists = false; //false by default
            for (int i = Schools.Count - 1; i >= 0; i--) //for every school
            {
                if (Schools[i].InstitutionCode == insCode) //if the required is found
                {
                    exists = true; 
                }
            }
            return exists;
        }
        public string getCurrentUserSchool()
        {
            if (currentSchoolID == -1) //if the user isn't enrolled onto a school,
            {
                return "NO SCHOOL"; //return NO SCHOOl. used by elements like label
                //in the panel outputting current school
            }
            return currentSchoolName;
        }

        public int getSchoolID(string institutionCode) 
        {
            int index = -1; //if a school isn't found, -1 is returned
            for (int i = Schools.Count - 1; i >= 0; i--) //for every school
            {
                if (Schools[i].InstitutionCode == institutionCode) //if the required is found
                {
                    index = i + 1; //IDs are always equal to the count. aka start from 1
                    //but this index goes down to zero
                    return index; 
                }
            }
            return index;
        }
    }
}
