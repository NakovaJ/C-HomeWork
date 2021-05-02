using System;
using System.Collections.Generic;
using System.Text;
using QuizzMillioner.Entities.Models;

namespace QuizzMillioner
{
    public static class QuestionsDB
    {
        public static List<List<Question>> AllQuestions { get; set; }
        static QuestionsDB()
        {
            AllQuestions = new List<List<Question>>()
            {
                //1
                new List<Question>(){
                    new Question("Which Disney character famously leaves a glass slipper behind at a royal ball?", "Pocahontas","Sleeping Beauty","Cindarela","Elsa",3),
                    new Question("A magnet would most likely attract which of the following?","Plastic","Metal","Wrong man","Wood",2),
                    new Question("How many seconds are in a minute?","30","100","60","1000",3)
                                    },
                //2
                new List<Question>()
                {
                    new Question("Which of these is a breed of spaniel?","King James","King John","King Charles","King George",3),
                    new Question("Which of these is regarded as a national symbol of Canada?","Maple Leaf","Fig Leaf","Fern Leaf","Tea Leaf",2),
                    new Question("A controversial situation which is awkward to deal with is often referred to as a ‘hot …’ what?","Leek","Onion","Potato","Tomato",3)
                },
                //3
                new List<Question>()
                {
                    new Question("According to Robert Burns, which food is the “Great chieftain o’ the pudding-race”?","Teacake","Haggis","Bacon roll","Sticky toffee pudding",2),
                    new Question("Someone expressing anger is said to be ‘venting their… ‘ what?","Spleen","Liver","Intestines","Pancreas",1),
                    new Question("In 1987, Whitney Houston topped the UK singles chart with ‘I Wanna…’ what ‘With Somebody’?","Sing","Dance","Spend time","Have a cuddle",2)

                },
                //4
                new List<Question>()
                {
                    new Question("What is the name of the character played by Daisy Ridley in ‘Star Wars: The Rise of Skywalker’?","Doh","Rey","Mee","Far",2),
                    new Question("The name of which of these types of sausage is derived from that of a German city?","Salami","Cumberland","Chorizo","Frankfurter",2),
                    new Question("Something that gives away the plot or outcome of a TV show is called a… what?","Fender","Splitter","Muffler","Spoiler",4)
                    
                },
                //5
                new List<Question>
                {
                    new Question("Which of these is the title of a famous artwork by Tracey Emin?","Our Settee","Your Bench","Desk","My Bed",4),
                    new Question("In the novel ‘The Lord of The Rings’, Frodo, Sam and Bilbo come from which region of Middle Earth?","The Green","The Borough","The Shire","The City",3),
                    new Question("What colour is the head of an adult male mallard?","Brown","Red","Black","Green",4)
                },
                //6
                new List<Question>
                {
                    new Question("The annual half-marathon the Great North Run starts in which UK city?","Newcastle","Sheffield","Liverpool","Leeds",1),
                    new Question("Which county cricket club play their home matches at the Oval?","Middlesex","Surrey","Essex","Hampshire",2),
                    new Question("In the ‘Transformers’ film franchise, who is the leader of the Decepticons?","Megaphone","Megabyte","Megatron","Megabus",3)
                    
                },
                //7
                new List<Question>
                {
                    new Question("For what reason did Professor Robert Kelly gain internet fame in 2017?","Mistaken identity on news","Chasing after his dog","Kids gatecrashed interview","Trying to catch a bat",3),
                    new Question("The liqueur crème de cassis is made from which fruit?","Apples","Pears","Blackcurrants","Gooseberries",3),
                    new Question("In 2000, which country joined rugby union’s Five Nations Championship to make it the Six Nations?","Argentina","Georgia","Italy","Spain",3)
                },
                //8
                new List<Question>
                {
                    new Question("A character named Ralph is elected leader of a group of boys at the beginning of which book?","Lord of the Flies","A Clockwork Orange","The Jungle Book","Brave New World",1),
                    new Question("Which day is the day of indepencence of Macedonia?","11th of October", "8th of September","2nd of August","24th of May",2),
                    new Question("Which of these words can be typed on a single row of a standard keyboard?","Cheese","Pork","Salad","Lager",3)
                },
                //9
                new List<Question>
                {
                    new Question("In Hokusai’s print ‘The Great Wave’, which mountain is depicted in the background?","Mount Emei","Mount Kailash","Mount Fuji","Mount Sinai",3),
                    new Question("‘Escape or Die Frying’ is a tagline for which film?","Chicken Run","Ratatouille","Free Willy","Babe",1),
                    new Question("Which term means a dry wind blowing from North Africa, that picks up moisture crossing the Mediterranean?","Mistral","Sargasso","Pampero","Sirocco",4)
                },
                //10
                new List<Question>
                {
                    new Question("According to the Highway Code, what shape is the standard sign giving the order to ‘Stop’?","Pentagon","Hexagon","Heptagon","Octagon",4),
                    new Question("The words ‘Royal Dutch’ appear in the full name of which company?","Esso","Shell","BP","Texaco",2),
                    new Question("Which of these real people has not been played on film or television by Benedict Cumberbatch?","Dominic Cummings","Julian Assange","Alan Turing","Tony Blair",1)
                },
                //11
                new List<Question>
                {
                    new Question("The national flag of which of these countries does not feature three horizontal stripes?","Russia","Romania","Hungary","Germany",2),
                    new Question("What is the ‘Temeraire’, the subject of an 1839 painting by J.M.W. Turner?","A gun ship","A harbour","A bridge","A steam train",1),
                    new Question("In the Bible, which land is said to be ‘east of Eden’?","Nineveh","Nod","Nazareth","Nimrud",2)
                },
                //12
                new List<Question>
                {
                    new Question("In mythology, which creature sprang from the blood of the Medusa?","Pegasus","Griffin","Hydra","Centaur",1),
                    new Question("The ruins of Urquhart Castle stand on the banks of which loch?","Loch Lomond","Loch Ness","Loch Broom","Loch Maree",2),
                    new Question("The name of which European capital city means ‘Bay of Smokes’ in its native language?","Copenhagen","Amsterdam","Reykjavik","Vilnius",3)
                },
                //13
                new List<Question>
                {
                    new Question("Which of these men was the first to win TWO Academy Awards for Best Director?","Stephen Spielberg","Clint Eastwood","Oliver Stone","Francis Ford Coppola",3),
                    new Question("The Scarlet Letter’ is a novel by which American writer?","Herman Melville","Nathanial Hawthorne","Jack London","John Steinbeck",2),
                    new Question("Oberon is the satellite of which planet?","Mercury","Neptune","Uranus","Mars",3)
                },
                //14
                new List<Question>
                {
                    new Question("Who wrote the opera ‘The Thieving Magpie’?","Rossini","Verdi","Donizetti","Puccini",1),
                    new Question("An insect’s hard outer skeleton is made mainly of what substance?","Chitin","Keratin","Glycogen","Lignin",1),
                    new Question("A number one followed by one hundred zeros is known by what name?","Googol","Megtron","Gigabit","Nanomole",1)
                },
                //15
                new List<Question>
                {
                    new Question("The word ‘batrachian’ describes which animals?","Monkeys and apes","Rats and mice","Frogs and toads","Hares and rabbits",3),
                    new Question("Which of these is the southernmost state capital on mainland USA?","Baton Rouge","Tallahassee","Little Rock","Phoenix",2),
                    new Question(" Which of these people was born the same year as Queen Elizabeth II?","Marilyn Monroe","Judy Garland","Audrew Hepburn","Julie Andrews",1)
                }
            };
            
        }
      
    }
}
