using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace gladiatorGame
{
    class FileManager
    {

        string AppPath = AppDomain.CurrentDomain.BaseDirectory;

        public Character CreateSave() // create a new character
        {

            Console.WriteLine("enter character name :");
            Character newChar = new Character(Console.ReadLine(),1,3,3,3,3,3,1);
            newChar.showCharInfo();
            Console.ReadKey();         
            
            new XDocument(
                    new XElement("root",
                        new XElement("name", newChar.name),
                        new XElement("level", newChar.level),
                        new XElement("experience",newChar.exp),
                        new XElement("team", newChar.team),
                        new XElement("stats",
                            new XElement("strength", newChar.strength),
                            new XElement("agility", newChar.agility),
                            new XElement("intelligence", newChar.intelligence),
                            new XElement("luck", newChar.luck),
                            new XElement("vitality", newChar.vitality)
                            ),
                        new XElement("Skills",
                            new XElement("Skill","1")
                            )
                        )
                    ).Save(AppPath + @"\savefile.xml");
            return newChar;

        }

        public void SaveCharacter(Character currentChar) // save the current character
        {
            new XDocument(
                    new XElement("root",
                        new XElement("name", currentChar.name),
                        new XElement("level", currentChar.level),
                        new XElement("experience", currentChar.exp),
                        new XElement("team", currentChar.team),
                        new XElement("stats",
                            new XElement("strength", currentChar.strength),
                            new XElement("agility", currentChar.agility),
                            new XElement("intelligence", currentChar.intelligence),
                            new XElement("luck", currentChar.luck),
                            new XElement("vitality", currentChar.vitality)
                            ),
                        new XElement("Skills",
                            new XElement("Skill", "1")
                            )
                        )
                    ).Save(AppPath + @"\savefile.xml");
        }

        public Character LoadSave() // load an existing character
        {
            string name = "";
            int level = 0, str = 0, agi = 0, intel = 0, lck = 0, vit = 0, exp = 0, team = 0;


            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(AppPath + @"\savefile.xml");

            foreach(XmlNode node in xdoc)
            {
                Console.WriteLine(node.Name);
                foreach(XmlNode childNode in node)
                {
                    if(childNode.Name == "name")
                    {
                        name = childNode.InnerXml;
                    }
                    else if(childNode.Name == "level")
                    {
                        level = Convert.ToInt16(childNode.InnerXml);
                    }
                    else if(childNode.Name == "experience")
                    {
                        exp = Convert.ToInt16(childNode.InnerXml);
                    }
                    else if (childNode.Name == "experience")
                    {
                        exp = Convert.ToInt16(childNode.InnerXml);
                    }
                    else if (childNode.Name == "team")
                    {
                        team = Convert.ToInt16(childNode.InnerXml);
                    }
                    
                    foreach(XmlNode grandChild in childNode)
                    {
                        if (grandChild.Name == "strength")
                        {
                            str = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "agility")
                        {
                            agi = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "intelligence")
                        {
                            intel = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "luck")
                        {
                            lck = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "vitality")
                        {
                            vit = Convert.ToInt16(grandChild.InnerXml);
                        }
                    }

                }           
            }
            Character loadChar = new Character(name, level, str, agi, intel, lck, vit, team);
            connectSkills(loadChar);
            return loadChar;
        }
      
        private void connectSkills(Character loadChar)
        {
            int ID = 0, basePow = 0, modifier = 0, modPow = 0, targetStat = 0;
            string name = ""; 

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(AppPath + @"\skills.xml");

            foreach(XmlNode node in xdoc)
            {
                foreach (XmlNode childNode in node)
                {                    

                    foreach (XmlNode grandChild in childNode)
                    {
                        if (grandChild.Name == "ID")
                        {
                            ID = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "BasePow")
                        {
                            basePow = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "Modifier")
                        {
                            modifier = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "Modpow")
                        {
                            modPow = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "TargetStat")
                        {
                            targetStat = Convert.ToInt16(grandChild.InnerXml);
                        }
                        else if (grandChild.Name == "Name")
                        {
                            name = grandChild.InnerXml;
                        }
                    }

                    loadChar.moveset.Add(new Action(ID, name, basePow, modifier, modPow, targetStat));
                }               
            }
        }

    }
}
