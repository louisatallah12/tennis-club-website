using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ATALLAH_Louis_TD_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le programme club de tennis");
            Console.WriteLine("Quelles fonctionnalités souhaitez-vous utiliser ?");
            int n = 1;
            while (n != 0)
            {
                Console.WriteLine("1-Module Membre");
                Console.WriteLine("2-Module Competition");
                Console.WriteLine("3-Module Statistique");
                Console.WriteLine("4-Module Autre");
                Console.WriteLine("0-Exit");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {

                    case 1:
                        ModuleMembre();
                        break;
                    case 2:
                        ModuleCompetition();
                        break;
                    case 3:
                        ModuleStatistique();
                        break;
                    case 4:
                        ModuleAutre();
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Fonction regroupant la première partie du cahier des charges intitulée "Module Membre"
        /// </summary>
        static void ModuleMembre()
        {
            List<Membre> membre = new List<Membre>();
            List<Administratif> personnel = new List<Administratif>();
            SortedList<int,Terrain> terrain = new SortedList<int,Terrain>();

            Terrain t1 = new Terrain(1, true);
            terrain.Add(t1.Numero, t1);
            
            var date = new DateTime(1999, 07, 12);
            Membre P = new Competiteur("Uh", "Jp", "villecresnes", date, 0760774526, "F",true, 35);
            
            membre.Add(P);
            membre.Add(new Competiteur("fr", "ce", "villecresnes", date, 0760774526, "M",false, 5));
            membre.Add(new Loisir("Ahm", "ace", "villecresnes", date, 0760774526, "F",false));
            Club c = new Club("asptt", 15, "montgeron", personnel,membre,terrain);
            membre.ForEach(x => x.Prix = x.Cout(c));                                    //pour chaque membre l'attribut prix prend comme valeur le résultat de la methode Cout selon les caractéristiques de l'individu (Ville et age)

            var born = new DateTime(1977, 5, 7);
            var ent1 = new DateTime(2007, 12, 12);
            personnel.Add(new Administratif("Abba", "Pascal", "Mandes", born, 0625458177, 1500, ent1));
            var ent2 = new DateTime(2012, 12, 12);
            personnel.Add(new Administratif("Martin", "Pierre", "Mandes", born, 0625458177, 1400, ent2));
            var ent3 = new DateTime(2011, 12, 12);
            personnel.Add(new Administratif("Muse", "Robert", "Mandes", born, 0625458177, 2000, ent3));

            Console.WriteLine("Taper 1 pour de l'affichage ou Taper 2 pour gérer les acteurs ou Taper 0 pour sortir");
            int n= Convert.ToInt32(Console.ReadLine());
            if(n==1)
            {
                while (n != 0)
                {
                    Console.WriteLine("Taper 1-Afficher les membres par type loisir ou competition");
                    Console.WriteLine("Taper 2-Afficher les membres par ordre alphabetique");
                    Console.WriteLine("Taper 3-Afficher les membres competition par classement");
                    Console.WriteLine("Taper 4-Afficher les membres par sexe");
                    Console.WriteLine("Taper 5-Afficher les membres qui n'ont pas réglé leur cotisation");
                    Console.WriteLine("Taper 6-Afficher les salariés par salaire");
                    Console.WriteLine("Taper 7-Afficher les membres par ancienneté");

                    Console.WriteLine("Taper 0-Pour sortir");

                    n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            List<Membre> listeCompet = membre.FindAll(x => x is Competiteur);
                            listeCompet.ForEach(x => Console.WriteLine(x));
                            List<Membre> listeLoisir = membre.FindAll(x => x is Loisir);
                            listeLoisir.ForEach(x => Console.WriteLine(x));
                            break;

                        case 2:
                            membre.Sort((x, y) => x.Nom.CompareTo(y.Nom));
                            membre.ForEach(x => Console.WriteLine(x));
                            break;

                        case 3:
                            List<Competiteur> comp = new List<Competiteur>();
                            comp.Add(new Competiteur("Uh", "Jp", "villecresnes", date, 0760774526, "M", false, 35));
                            comp.Add(new Competiteur("fr", "ce", "villecresnes", date, 0760774526, "M", true, 5));
                            comp.Sort();
                            comp.ForEach(x => Console.WriteLine(x));
                            break;

                        case 4:
                            membre.Sort((x, y) => x.Sexe.CompareTo(y.Sexe));
                            membre.ForEach(x => Console.WriteLine(x));
                            break;

                        case 5:
                            Console.WriteLine("Les membres à jour dans leur adhésion :");
                            List<Membre> Laliste = membre.FindAll(x => x.Cotisation_Payee == true);
                            Laliste.ForEach(x => Console.WriteLine(x));
                            Console.WriteLine("Les membres qu'il faut relancer pour le reglement de la cotisation :");
                            Laliste = membre.FindAll(x => x.Cotisation_Payee != true);
                            Laliste.ForEach(x => Console.WriteLine(x));
                            break;

                        case 6:
                            personnel.Sort();
                            personnel.ForEach(x => Console.WriteLine(x));
                            break;

                        case 7:
                            personnel.Sort((x, y) => x.Entree.CompareTo(y.Entree));
                            personnel.ForEach(x => Console.WriteLine(x));
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("///////////////////////////////");

                }
            }
            if (n == 2)
            {
                while (n != 0)
                {
                    Console.WriteLine("Taper 1-Ajouter un membre loisir");
                    Console.WriteLine("Taper 2-Ajouter un membre competition");
                    Console.WriteLine("Taper 3-Ajouter un entraineur");
                    Console.WriteLine("Taper 4-Ajouter un personnel administratif");
                    Console.WriteLine("Taper 5-Supprimer un membre ou entraineur");
                    Console.WriteLine("Taper 6-Supprimer un personnel administratif");
                    Console.WriteLine("Taper 7-Modifier l'adresse d'un membre ou entraineur");
                    Console.WriteLine("Taper 8-Modifier l'adresse d'un personnel administratif");
                    Console.WriteLine("Taper 9-Modifier le numéro de telephone d'un membre ou entraineur");
                    Console.WriteLine("Taper 10-Modifier le numéro de telephone d'un personnel administratif");
                    Console.WriteLine("Taper 11-Verifier si un membre a payé sa cotisaton");

                    Console.WriteLine("Taper 12-Afficher la liste des membres MAJ");
                    Console.WriteLine("Taper 13-Afficher la liste du personnel MAJ");

                    Console.WriteLine("Taper 0-Pour sortir");
                    n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            
                                Console.WriteLine("Nom : ");
                                string nom = Console.ReadLine();
                                Console.WriteLine("Prenom : ");
                                string prenom = Console.ReadLine();
                                Console.WriteLine("Adresse : ");
                                string adresse = Console.ReadLine();
                                Console.WriteLine("Sexe : ");
                                string sexe = Console.ReadLine();
                                Console.WriteLine("Tel : ");
                                int tel = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Date de naissance AAAA,M,J : ");
                                var dateN = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Cotisation payée oui ou non : ");
                                string cotis = Console.ReadLine();
                                bool cotisation = false;
                                if (cotis == "oui") cotisation = true;
                            try
                            {
                                membre.Add(new Loisir(nom, prenom, adresse, dateN, tel, sexe, cotisation));
                                Console.WriteLine("Le membre a bien été ajouté");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 2:
                            
                                Console.WriteLine("Nom : ");
                                nom = Console.ReadLine();
                                Console.WriteLine("Prenom : ");
                                prenom = Console.ReadLine();
                                Console.WriteLine("Adresse : ");
                                adresse = Console.ReadLine();
                                Console.WriteLine("Sexe : ");
                                sexe = Console.ReadLine();
                                Console.WriteLine("Tel : ");
                                tel = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Date de naissance AAAA,M,J : ");
                                dateN = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Cotisation payée oui ou non : ");
                                cotis = Console.ReadLine();
                                cotisation = false;
                                if (cotis == "oui") cotisation = true;
                                Console.WriteLine("Classement : ");
                                double classement1 = Convert.ToDouble(Console.ReadLine());
                            try
                            {
                                membre.Add(new Competiteur(nom, prenom, adresse, dateN, tel, sexe, cotisation, classement1));
                                Console.WriteLine("Le membre a bien été ajouté");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }

                            break;

                        case 3:
                            
                                Console.WriteLine("Nom : ");
                                nom = Console.ReadLine();
                                Console.WriteLine("Prenom : ");
                                prenom = Console.ReadLine();
                                Console.WriteLine("Adresse : ");
                                adresse = Console.ReadLine();
                                Console.WriteLine("Sexe : ");
                                sexe = Console.ReadLine();
                                Console.WriteLine("Tel : ");
                                tel = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Date de naissance AAAA,M,J : ");
                                dateN = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Cotisation payée oui ou non : ");
                                cotis = Console.ReadLine();
                                cotisation = false;
                                if (cotis == "oui") cotisation = true;
                                Console.WriteLine("Classement : ");
                                double classement = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Salaire € : ");
                                double salaire = Convert.ToDouble(Console.ReadLine());
                                var dateEntree = DateTime.Now;
                                Console.WriteLine("Statut Independant ou Salarié : ");
                                string statut = Console.ReadLine();
                            try
                            {
                                membre.Add(new Entraineur(nom, prenom, adresse, dateN, tel, sexe, cotisation, classement, salaire, dateEntree, statut));
                                Console.WriteLine("Le membre a bien été ajouté");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;


                        case 4:
                            
                                Console.WriteLine("Nom : ");
                                nom = Console.ReadLine();
                                Console.WriteLine("Prenom : ");
                                prenom = Console.ReadLine();
                                Console.WriteLine("Adresse : ");
                                adresse = Console.ReadLine();
                                Console.WriteLine("Tel : ");
                                tel = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Date de naissance AAAA,M,J : ");
                                dateN = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Salaire € : ");
                                salaire = Convert.ToDouble(Console.ReadLine());
                                dateEntree = DateTime.Now;
                            try
                            {
                                personnel.Add(new Administratif(nom, prenom, adresse, dateN, tel, salaire, dateEntree));
                                Console.WriteLine("Le personnel a bien été ajouté");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }

                            break;

                        case 5:
                            Console.WriteLine("Nom du membre à retirer : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du membre à retirer : ");
                            prenom = Console.ReadLine();
                            try
                            {
                                membre.Remove(membre.Find(x => x.Nom == nom && x.Prenom == prenom));
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 6:
                            Console.WriteLine("Nom du personnel à retirer : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du personnel à retirer : ");
                            prenom = Console.ReadLine();
                            try
                            {
                                personnel.Remove(personnel.Find(x => x.Nom == nom && x.Prenom == prenom));
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 7:
                            Console.WriteLine("Nom du membre à modifier l'adresse : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du membre à modifier l'adresse : ");
                            prenom = Console.ReadLine();
                            Console.WriteLine("Nouvelle adresse : ");
                            adresse = Console.ReadLine();
                            try
                            {
                                membre.Find(x => x.Nom == nom && x.Prenom == prenom).Adresse = adresse;
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 8:
                            Console.WriteLine("Nom du personnel à modifier l'adresse : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du personnel à modifier l'adresse : ");
                            prenom = Console.ReadLine();
                            Console.WriteLine("Nouvelle adresse : ");
                            adresse = Console.ReadLine();
                            try
                            {

                                personnel.Find(x => x.Nom == nom && x.Prenom == prenom).Adresse = adresse;
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 9:
                            Console.WriteLine("Nom du membre à modifier le telephone : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du membre à modifier le telephone : ");
                            prenom = Console.ReadLine();
                            Console.WriteLine("Nouveau numero : ");
                            tel = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                membre.Find(x => x.Nom == nom && x.Prenom == prenom).Telephone = tel;
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 10:
                            Console.WriteLine("Nom du personnel à modifier le telephone : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du personnel à modifier le telephone : ");
                            prenom = Console.ReadLine();
                            Console.WriteLine("Nouveau numero : ");
                            tel = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                personnel.Find(x => x.Nom == nom && x.Prenom == prenom).Telephone = tel;
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case 11:
                            Console.WriteLine("Nom du membre : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du membre : ");
                            prenom = Console.ReadLine();
                            try
                            {
                                Console.WriteLine(membre.Find(x => x.Nom == nom && x.Prenom == prenom).Verification_Paiement());
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;
                        
                        case 12:
                            membre.ForEach(x => x.Prix = x.Cout(c));
                            List<Membre> listeCompet = membre.FindAll(x => x is Competiteur);
                            listeCompet.Sort();
                            listeCompet.ForEach(x => Console.WriteLine(x));
                            List<Membre> listeLoisir = membre.FindAll(x => x is Loisir);
                            listeLoisir.Sort((x, y) => x.Nom.CompareTo(y.Nom));
                            listeLoisir.ForEach(x => Console.WriteLine(x));
                            break;

                        case 13:
                            personnel.Sort();
                            personnel.ForEach(x => Console.WriteLine(x));
                            break;

                        default:
                            break;

                    }
                    Console.WriteLine("///////////////////////////////");

                }

            }
        }
        static void ModuleCompetition()
        {
            List<Competiteur> simple = new List<Competiteur>();
            var date = new DateTime(1985, 7, 7);
            List<Competition> competitions = new List<Competition>();
            List<Competiteur> joueur = new List<Competiteur>();
            joueur.Add(new Competiteur("Armand", "Jules", "villecresnes", date, 0760774526, "M", false, 15));
            joueur.Add(new Competiteur("Aimé", "Jordan", "villecresnes", date, 0760774526, "M", true, 25));
            joueur.Add(new Competiteur("Martin", "Arnaud", "villecresnes", date, 0760774526, "M", false, 5));

            List<Equipe> listeEquipes = new List<Equipe>();
            competitions.Add(new Team("Cup", "regional", 17, 35, 5, 40, 30, 15, "M", 12, 28, listeEquipes));
            competitions.Add(new Team("League", "national", 17, 35, 5, 40, 30, 15, "M", 12, 28, listeEquipes));
            competitions.Add(new Team("Challenge Cup", "regional", 17, 35, 5, 40, 30, 15, "M", 12, 28, listeEquipes));

            Equipe e = new Equipe();
            
            Console.WriteLine("Taper 1 pour entrer dans le module competition ou 0 pour sortir");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n != 0)
            {
                Console.WriteLine("1-Ajouter une competition simple");
                Console.WriteLine("2-Ajouter une competition en equipe");
                Console.WriteLine("3-Ajouter une equipe");
                Console.WriteLine("4-Ajouter des joueurs dans une competition simple");
                Console.WriteLine("5-Ajouter des joueurs dans une competition en equipe");
                Console.WriteLine("6-Verifier que les listes de joueurs sont complètes");

                Console.WriteLine("7-Affichage des competitions créées");
                Console.WriteLine("8-Attribuer une victoire à un joueur");
                Console.WriteLine("9-Attribuer une defaite à un joueur");
                Console.WriteLine("10-Attribuer une annulation à un joueur");
                Console.WriteLine("11-Afficher le bilan de la competition");
                Console.WriteLine("12-Afficher les compétiteurs ");
                Console.WriteLine("Taper 0-Pour sortir");

                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Nom : ");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Niveau : ");
                        string niveau = Console.ReadLine();
                        Console.WriteLine("Age Minimum : ");
                        int age_min = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Classement Maximunm : ");
                        double classment_max = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Duree en jours : ");
                        int duree = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nombre de matchs : ");
                        int nb_match = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Prix : ");
                        int prix = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nombre minimal de joueur : ");
                        int nb_joueur = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Sexe : ");
                        string sexe_compet = Console.ReadLine();
                        try
                        {
                            competitions.Add(new Simple(nom, niveau, age_min, classment_max, simple, duree, nb_match, prix, nb_joueur, sexe_compet));
                            Console.WriteLine("La competition simple " + nom + " a bien été créée");

                        }

                        catch (Exception e1)
                        {
                            Console.WriteLine(e1);
                        }

                        break;

                    case 2:
                        Console.WriteLine("Nom : ");
                        nom = Console.ReadLine();
                        Console.WriteLine("Niveau : ");
                        niveau = Console.ReadLine();
                        Console.WriteLine("Age Minimum : ");
                        age_min = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Classement Maximunm : ");
                        classment_max = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Duree en jours : ");
                        duree = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nombre de matchs : ");
                        nb_match = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Prix : ");
                        prix = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nombre minimal de joueur : ");
                        nb_joueur = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Sexe : ");
                        sexe_compet = Console.ReadLine();
                        Console.WriteLine("Nombre de match simples : ");
                        int matchs_simples = Convert.ToInt32(Console.ReadLine());
                        int matchs_doubles = nb_match - matchs_simples;
                        try
                        {
                            competitions.Add(new Team(nom, niveau, age_min, classment_max, duree, nb_match, prix, nb_joueur, sexe_compet, matchs_simples, matchs_doubles, listeEquipes));
                            Console.WriteLine("La competition en equipe " + nom + " a bien été créée");
                        }
                        catch(Exception e1)
                        {
                            Console.WriteLine(e1);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Nom de la competition dans laquelle l'equipe va être ajoutée: ");
                        string name = Console.ReadLine();
                        Team cpt = competitions.Find(x => x.Nom == name) as Team ;          //competitions est une liste de competition, or il faut recuperer la competition en equipe c'est pourquoi on caste pour avoir la bonne interpretation
                        Console.WriteLine("Nom d'equipe : ");
                        nom = Console.ReadLine();
                        int numero = e.N;
                        try
                        {
                            cpt.Equipe.Add(new Equipe(nom, simple, numero));
                            Console.WriteLine("L'equipe numero " + numero + " a bien été ajoutéà la competition " + name);
                        }
                        catch(Exception e1)
                        {
                            Console.WriteLine(e1);
                        }
                        break;

                    case 4:
                        int c=1;
                        while (c != 0)      //boucle while qui permet d'ajouter de joueur en un seul coup 
                        {
                            Console.WriteLine("Nom du joueur à ajouter : ");        // les competiteurs sont des membres, il suffit de les rechercher dans la liste pour les ajouter
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom : ");
                            string prenom = Console.ReadLine();
                            Console.WriteLine("Nom de la competition simple dans laquelle vous souhaitez l'ajouter : ");
                            name = Console.ReadLine();
                            try
                            {
                                Simple comp = competitions.Find(x => x.Nom == name) as Simple;          //on caste la competition en simple 
                                Competiteur participant = joueur.Find(x => x.Nom == nom && x.Prenom == prenom) as Competiteur;
                                comp.Ajouter(participant);
                                joueur.Add(participant);
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                            Console.WriteLine("Taper 1 pour ajouter un nouveau joueur ou 0 pour sortir");
                            c = Convert.ToInt32(Console.ReadLine());
                        }

                        break;

                    case 5:
                        c = 1;
                        while (c != 0)      //boucle while qui permet d'ajouter de joueur en un seul coup 
                        {
                            Console.WriteLine("Nom du joueur à ajouter : ");            //les competiteurs sont des membres, il suffit de les rechercher dans la liste pour les ajouter
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom : ");
                            string prenom = Console.ReadLine();
                            Console.WriteLine("Nom de la competition en equipe dans laquelle vous souhaitez l'ajouter : ");
                            name = Console.ReadLine();
                            Console.WriteLine("Nom de l'equipe dans laquelle vous souhaitez l'ajouter : ");
                            string nom_equipe = Console.ReadLine();
                            try
                            {
                                Team comp = competitions.Find(x => x.Nom == name) as Team;          //on caste la competition en Team 
                                Equipe lateam = comp.Equipe.Find(x => x.Nom == nom_equipe);
                                Competiteur participant = joueur.Find(x => x.Nom == nom && x.Prenom == prenom) as Competiteur;
                                comp.Ajouter(participant, lateam);
                                joueur.Add(participant);
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                            Console.WriteLine("Taper 1 pour ajouter un nouveau joueur ou 0 pour sortir");
                            c = Convert.ToInt32(Console.ReadLine());
                        }
                        break;

                    case 6:
                        competitions.ForEach(x => x.Verification());
                        break;

                    case 7:
                        competitions.ForEach(delegate (Competition x) { Console.WriteLine(x+"\n----------------------"); });
                        break;
                    
                    case 8:
                        Console.WriteLine("Simple ou Double : ");
                        string reponse = Console.ReadLine();
                        if (reponse == "Double")
                        {
                            Console.WriteLine("Nom du premier vainqueur : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du premier vainqueur : ");
                            name = Console.ReadLine();
                            (joueur.Find(x => x.Nom == nom && x.Prenom == name) as Competiteur).MatchDoubleGagné();
                            Console.WriteLine("Nom du second vainqueur : ");
                            string nom1 = Console.ReadLine();
                            Console.WriteLine("Prenom du second vainqueur : ");
                            string name1 = Console.ReadLine();
                            try
                            {
                                (joueur.Find(x => x.Nom == nom1 && x.Prenom == name1) as Competiteur).MatchDoubleGagné();
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nom : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom : ");
                            string prenom = Console.ReadLine();
                            try
                            {
                                (joueur.Find(x => x.Nom == nom && x.Prenom == prenom) as Competiteur).MatchSimpleGagné();
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine("Simple ou Double : ");
                         reponse = Console.ReadLine();
                        if (reponse == "Double")
                        {
                            Console.WriteLine("Nom du premier perdant : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du premier perdant : ");
                            name = Console.ReadLine();
                            (joueur.Find(x => x.Nom == nom && x.Prenom == name) as Competiteur).MatchPerdu();
                            Console.WriteLine("Nom du second perdant : ");
                            string nom1 = Console.ReadLine();
                            Console.WriteLine("Prenom du second perdant : ");
                            string name1 = Console.ReadLine();
                            try
                            {
                                (joueur.Find(x => x.Nom == nom1 && x.Prenom == name1) as Competiteur).MatchPerdu();
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nom : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom : ");
                            string prenom = Console.ReadLine();
                            try
                            {
                                (joueur.Find(x => x.Nom == nom && x.Prenom == prenom) as Competiteur).MatchPerdu();
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                        break;

                    case 10:
                        Console.WriteLine("Simple ou Double : ");
                        reponse = Console.ReadLine();
                        if (reponse == "Double")
                        {
                            Console.WriteLine("Nom du premier joueur : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom du premier joueur : ");
                            name = Console.ReadLine();
                            (joueur.Find(x => x.Nom == nom && x.Prenom == name) as Competiteur).MatchAnnulé();
                            Console.WriteLine("Nom du second joueur : ");
                            string nom1 = Console.ReadLine();
                            Console.WriteLine("Prenom du second joueur : ");
                            string name1 = Console.ReadLine();
                            try
                            {
                                (joueur.Find(x => x.Nom == nom1 && x.Prenom == name1) as Competiteur).MatchAnnulé();
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nom : ");
                            nom = Console.ReadLine();
                            Console.WriteLine("Prenom : ");
                            string prenom = Console.ReadLine();
                            try
                            {
                                (joueur.Find(x => x.Nom == nom && x.Prenom == prenom) as Competiteur).MatchAnnulé();
                            }
                            catch(Exception e1)
                            {
                                Console.WriteLine(e1);
                            }
                        }
                        
                        break;

                    case 11:
                        joueur.ForEach(x => Console.WriteLine(x +"\n"+x.Point+" Points\n"+ x.Victoire+" Victoires\n"+x.Defaite+" Defaites\n------------"));
                        break;

                    case 12:
                        joueur.ForEach(x => Console.WriteLine(x));
                        break;
                    default:
                        break;
                }
                Console.WriteLine("///////////////////////////////");

            }
             
        }
        static void ModuleStatistique()
        {
            List<Competition> competitions = new List<Competition>();
            List<Equipe> listeEquipes = new List<Equipe>();
            List<Competiteur> simple = new List<Competiteur>();

            competitions.Add(new Team("Cup", "regional", 17, 35, 5, 40, 30, 15, "M", 12, 28, listeEquipes));
            competitions.Add(new Team("League", "national", 17, 35, 5, 40, 30, 15, "M", 12, 28, listeEquipes));
            competitions.Add(new Team("Challenge Cup", "regional", 17, 35, 5, 40, 30, 15, "M", 12, 28, listeEquipes));
            Competition c1 = new Simple("Premiership", "departementale", 25, 5.4, simple, 2, 40, 25, 12, "F");
            competitions.Add(c1);

            var date = new DateTime(1985, 7, 7);
            var date2 = new DateTime(2010, 10, 15);
            simple.Add(new Competiteur("Armand", "Jules", "villecresnes", date, 0760774526, "M", false, 15,2,2));
            simple.Add(new Competiteur("Aimé", "Jordan", "villecresnes", date, 0760774526, "M", true, 25,5,5,6));
            simple.Add(new Competiteur("Martin", "Arnaud", "villecresnes", date, 0760774526, "M", false, 5,8,12,5));
            simple.Add(new Competiteur("Martine", "Catherine", "villecresnes", date, 0760774526, "F", false, 5,7,4,2));
            simple.Add(new Competiteur("Dubuit", "Chloe", "villecresnes", date, 0760774526, "F", false, 5,2,5,5));
            simple.Add(new Competiteur("Marshall", "Emmanuelle", "villecresnes", date, 0760774526, "F", false, 5, 4, 4, 4));
            simple.Add(new Competiteur("Buhr", "Ines", "villecresnes", date2, 0760774526, "F", false, 5, 2, 5, 5));
            simple.Add(new Competiteur("Baguette", "Lea", "villecresnes", date2, 0760774526, "F", false, 5, 2, 5, 5));
            simple.Add(new Competiteur("Laporte", "Aymeric", "villecresnes", date2, 0760774526, "M", false, 5, 2, 5, 5));


            List<Membre> membre = new List<Membre>();
            List<Administratif> personnel = new List<Administratif>();
            SortedList<int, Terrain> terrain = new SortedList<int, Terrain>();

            Club club = new Club("Asptt", 12, "villecresnes", personnel, membre, terrain);

            Console.WriteLine("Taper 1 pour entrer dans le module statistique ou 0 pour sortir");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n != 0)
            {
                Console.WriteLine("1-Afficher le nombre de competitions restantes et celui déà réalisées");
                Console.WriteLine("2-Historique des joueurs");
                Console.WriteLine("3-Nombre moyen de joueur par competition");
                Console.WriteLine("4-Total matchs gagnés ou perdus par le club");
                Console.WriteLine("5-Afficher les résultats par sexe");

                Console.WriteLine("Taper 0-Pour sortir");

                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        int competition_restante = club.Compet - c1.Nombre_Competition;
                        Console.WriteLine("Il reste à oraganiser " + competition_restante + " competitions\nPour " + c1.Nombre_Competition + " competition(s) d'organisée(s)");
                        break;

                    case 2:
                        simple.ForEach(x => x.StatistiqueJoueur());
                        break;

                    case 3:
                        int nb = 0;
                        foreach(Competition tournament in competitions)
                        {
                            nb += tournament.Nb_Joueur;
                        }
                        double moyenne = nb / c1.Nombre_Competition;
                        Console.WriteLine("En moyenne il y a au moins " + moyenne + " joueurs par competition");
                        break;

                    case 4:
                        int v = 0;
                        int d = 0;
                        foreach(Competiteur champion in simple)
                        {
                            v += champion.Victoire;
                            d += champion.Defaite;
                        }
                        Console.WriteLine("Le club a gagné pour l'instant " + v + " matchs et perdu " + d + " matchs");
                        break;

                    case 5:
                        try
                        {
                            List<Competiteur> hommes = simple.FindAll(x => x.Sexe == "M" && x.Age() >= 18);
                            List<Competiteur> femmes = simple.FindAll(x => x.Sexe == "F" && x.Age() >= 18);
                            List<Competiteur> juniors = simple.FindAll(x => x.Age() < 18);

                            int v_h = 0;
                            int d_h = 0;
                            int pts_h = 0;
                            foreach (Competiteur h in hommes)
                            {
                                v_h += h.Victoire;
                                d_h += h.Defaite;
                                pts_h += h.Point;
                            }
                            Console.WriteLine("La catégorie homme totalise : \nVictoires : " + v_h + "\nDefaites : " + d_h + "\nPoints : " + pts_h + "\n-------------------------------------------");

                            int v_f = 0;
                            int d_f = 0;
                            int pts_f = 0;
                            foreach (Competiteur f in femmes)
                            {
                                v_f += f.Victoire;
                                d_f += f.Defaite;
                                pts_f += f.Point;
                            }
                            Console.WriteLine("La catégorie femme totalise : \nVictoires : " + v_f + "\nDefaites : " + d_f + "\nPoints : " + pts_f + "\n-------------------------------------------");

                            int v_j = 0;
                            int d_j = 0;
                            int pts_j = 0;
                            foreach (Competiteur j in juniors)
                            {
                                v_j += j.Victoire;
                                d_j += j.Defaite;
                                pts_j += j.Point;
                            }
                            Console.WriteLine("La catégorie junior totalise : \nVictoires : " + v_j + "\nDefaites : " + d_j + "\nPoints : " + pts_j + "\n-------------------------------------------");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("///////////////////////////////");

            }
        }
        static void ModuleAutre()
        {
            List<Administratif> personnel = new List<Administratif>();
            List<Membre> membre = new List<Membre>();
            SortedList<int, Terrain> terrain = new SortedList<int, Terrain>();
            Club club = new Club("ASPTT", 10, "villecresnes", personnel, membre, terrain);
            Terrain T1 = new Terrain(1, true);
            terrain.Add(T1.Numero, T1);
            Terrain T2 = new Terrain(2, true);
            terrain.Add(T2.Numero, T2);
            Terrain T3 = new Terrain(3, true);
            terrain.Add(T3.Numero, T3);
            var date = new DateTime(1960, 11, 14);
            Loisir Mr = new Loisir("Pierre", "Jean", "villecresnes", date, 0654585759, "M", true);
            List<Loisir> loisir = new List<Loisir>();
            loisir.Add(Mr);
            membre.Add(Mr);
            Console.WriteLine("Taper 1 pour entrer dans le module autre ou 0 pour sortir");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n != 0)
            {
                Console.WriteLine("1-Afficher les terrains occupés et disponibles");
                Console.WriteLine("2-Reserver un terrain ");
                Console.WriteLine("3-Libérer un terrain");
                Console.WriteLine("4-Fermer un terrain");       //impossible de l'utiliser
                Console.WriteLine("5-Ajouter un nouveau terrain ");

                Console.WriteLine("Taper 0-Pour sortir");

                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        for (int i = 0; i < terrain.Count; i++)
                        {
                            Console.WriteLine(terrain.ElementAt(i).Value);
                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Nom du membre loisir : ");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Prenom du membre loisir : ");
                        string prenom = Console.ReadLine();
                        try
                        {

                            loisir.Find(x => x.Nom == nom && x.Prenom == prenom).ReserverTerrain(club); 
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        break;

                    case 3:
                        Console.WriteLine("Numero du terrain à libérer : ");
                        int num = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            Terrain t = terrain.ElementAt(terrain.IndexOfKey(num)).Value;
                            club.LibererTerrain(t);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Numero du terrain à fermer : ");
                        num = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            //terrain.RemoveAt(terrain.IndexOfKey(num));   2 façons de faire
                            terrain.Remove(num);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Numero du nouveau terrain : ");
                        num = Convert.ToInt32(Console.ReadLine());
                        try { terrain.Add(num, new Terrain(num)); }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("//////////////////////////////////////");
            }
        }

        //les  try catch permettent d'eviter que le programme ne crash
    }
}
