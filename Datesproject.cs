//Ce programme affiche le nom du jour de la semaine, le quantième du jour et s'il s'agit d'un jour férié ou non.
//Auteur : Lilian BOUVIER

//Je le précise ic pour l'utiliser tout au long du programme :
using System;

class DatesProject
{
	static void Main()
	{
		//Déclarations:
		string date;
		string jour;
		string mois;
		string annee;
		bool continuer;

		//Initialisations :
		continuer = true;

		Console.WriteLine("Quelle est votre date ?  FORMAT : YYYY/MM/JJ");
		date = Console.ReadLine();

		//Test d'entrée :
			if(date=="")
			{
				continuer=false;
			}

		while(continuer)
		{
			

			//Extractions :
			annee= date.Substring(0,4);
			mois= date.Substring(5,2);
			jour= date.Substring(8,2);

			//Appel:
			Affichage(jour, mois, annee);



			//On attend la fermeture :
			Console.WriteLine("Entrez une autre date ou appuyez sur ENTRER pour quitter...");
			date=Console.ReadLine();

			//Test d'entrée :
			if(date=="")
			{
				continuer=false;
			}
		}
		

		


	}



//Définition de EstFerie :
	/*
	EstFerie : string : bool : Retourne le caractère ferié ou non d'un jour en France

	Paramètres :
		pJour : string
		pMois : string
		pAnnee : string

	Retour :
		estFerie : string : Caractère ferié ou non d'un jour en France

	Locales :


	*/

	public static string EstFerie(string pJour, string pMois, string pAnnee)
	{
		//Déclarations :
		string estFerie;

		//Inititalisations :
		estFerie = "N'est pas ferie en France.";

		//Vérifications :

		//Jour de l'an
		if(pJour == "01" && pMois=="01" && int.Parse(pAnnee)>= 1810 )
		{
			estFerie = "Est ferie en France depuis l'an 1810.";
		}

		//Vendredi Saint (en Alsace-Moselle):
		if((pMois+"/"+pJour)== VendrediSaint(int.Parse(pAnnee)))
		{
			estFerie = "Est ferie en France depuis l'an 1801 SEULEMENT EN ALSACE-MOSELLE (Vendredi Saint).";
		}

		//Lundi de Paques:
		if((pMois+"/"+pJour)== LundiPaques(int.Parse(pAnnee)))
		{
			estFerie = "Est ferie en France depuis l'an 1801 (Lundi de Paques).";
		}

		//Premier Mai :
		if(pJour == "01" && pMois=="05"&& int.Parse(pAnnee)>= 1947)
		{
			estFerie="Est ferie en France depuis l'an 1947.";
		}

		//Huit Mai :
		if(pJour == "08" && pMois=="05"&& int.Parse(pAnnee)>= 1981)
		{
			estFerie="Est ferie en France depuis l'an 1981.";
		}

		//Ascension :
		if((pMois+"/"+pJour)== Ascension(int.Parse(pAnnee)))
		{
			estFerie = "Est ferie en France depuis l'an 1801 (Ascension).";
		}

		//Pentecote :
		if((pMois+"/"+pJour)== Pentecote(int.Parse(pAnnee)))
		{
			estFerie = "Est ferie en France depuis l'an 2008 (Pentecote).";
		}

		//14 Juillet :
		if(pJour == "14" && pMois=="07"&& int.Parse(pAnnee)>= 1880)
		{
			estFerie="Est ferie en France depuis l'an 1880 (14 Juillet).";
		}

		//Assomption :
		if(pJour == "15" && pMois=="08")
		{
			estFerie="Est ferie en France depuis l'an 1801 (Assomption).";
		}

		//Toussaint :
		if(pJour == "01" && pMois=="11"&& int.Parse(pAnnee)>= 1580)
		{
			estFerie="Est ferie en France depuis l'an 1580 (Toussaint).";
		}

		//Armistice :
		if(pJour == "11" && pMois=="11"&& int.Parse(pAnnee)>= 1922)
		{
			estFerie="Est ferie en France depuis l'an 1922 (Armistice).";
		}

		//Noel :
		if(pJour == "25" && pMois=="12")
		{
			estFerie="Est ferie en France (Noel).";
		}

		//Saint-Etienne :
		if(pJour == "26" && pMois=="12"&& int.Parse(pAnnee)>= 1918)
		{
			estFerie="Est ferie en France depuis l'an 1918 (Saint-Etienne).";
		}

		//Retour :
		return estFerie;
	}




//Definition de VendrediSaint :
	/*
	VendrediSaint : fonct : string : Retourne la date du vendredi saint de l'annee au format : MM/DD

	Paramètre:
		pAnnee : int 

	Retour :
		vendrediSaint : string : Date formatée du vendredi Saint de l'annee

	Locales :
		A : int 
		B : int
		C : int 
		D : int 
		E : int

		moisPaques : int
		jourPaques : int

		jourVendrediSaint : int
		moisVendrediSaint : int

	*/

	public static string VendrediSaint(int pAnnee)
	{
		//Déclarations :
		int A;
		int B;
		int C;
		int D;
		int E;
		int moisPaques;
		int jourPaques;

		int jourVendrediSaint;
		int moisVendrediSaint;

		string vendrediSaint;

		//Initialisations :
		A = pAnnee %19;
		B = pAnnee % 4;
		C = pAnnee % 7;
		D = ((A*19)+24) % 30;


		//Closes aux limites pour D:
		if(D==29 || (D==28 && A>10))
		{
			D-=1;
		}

		// On détermine le jour et le mois du dimanche de paques :
		E = ((2 * B) + (4 * C) + (6 * D) + 5) % 7;
		if((D+E) >= 10)
		{
			jourPaques = D + E - 9;
			moisPaques = 4;
		}
		else
		{
			jourPaques =22 + D + E;
			moisPaques=3;
		}

		//On détermine maintenant la date du vendredi saint :
		jourVendrediSaint = jourPaques;
		moisVendrediSaint = moisPaques;

		while(NumJourSem(jourVendrediSaint, moisVendrediSaint, pAnnee)!= 5)
		{
			jourVendrediSaint -=1;
			if (jourVendrediSaint < 0)
			{
				jourVendrediSaint = 31;
				moisVendrediSaint -=1;
			}
		}

		//Mise au format :
		if(jourVendrediSaint <10)
		{
			vendrediSaint = "0"+moisVendrediSaint.ToString()+"/"+"0"+jourVendrediSaint.ToString();
		}
		else
		{
			vendrediSaint = "0"+moisVendrediSaint.ToString()+"/"+jourVendrediSaint.ToString();
		}

		//Retour :
		

		return vendrediSaint;



	}




//Définition de Pentecote :
	/*
	Pentecote: fonct : string : Date de Pentecote au format MM/DD

	Paramètres :
		pAnnee : int 

	Retour :
		pentecote : string : Date de pentecote au format MM/DD

	Locales :
		jourVendrediSaint : int
		moisVendrediSaint : int
		vendrediSaint: string : Date du vendredi saint au format MM/DD
		i : int : itérations de boucles
	*/

	public static string Pentecote(int pAnnee)
	{
		//Déclarations :
		string pentecote;
		int moisVendrediSaint;
		int jourVendrediSaint;
		string vendrediSaint;
		int i;

		//Initialisations :
		vendrediSaint = VendrediSaint(pAnnee);

		//Extractions :
		moisVendrediSaint = int.Parse(vendrediSaint.Substring(0,2));
		jourVendrediSaint = int.Parse(vendrediSaint.Substring(3,2));

		//Calculs :
		for(i=1 ; i<=51; i++)
		{
			jourVendrediSaint++;
			if (jourVendrediSaint>JoursMax(moisVendrediSaint, EstBissextile(pAnnee)))
			{
				moisVendrediSaint+=1;
				jourVendrediSaint =1;
			}
		}

		//Mise au format :
		if(jourVendrediSaint <10)
		{
			pentecote = "0"+moisVendrediSaint.ToString()+"/"+"0"+jourVendrediSaint.ToString();
		}
		else
		{
			pentecote= "0"+moisVendrediSaint.ToString()+"/"+jourVendrediSaint.ToString();
		}

		//Retour :
		

		return pentecote;



	}




//Définition de Ascension :
	/*
	Ascension : fonct : string : Date de l'ascension au format MM/DD

	Paramètres :
		pAnnee : int 

	Retour :
		ascension : string : Date de l'ascension au format MM/DD

	Locales :
		jourVendrediSaint : int
		moisVendrediSaint : int
		vendrediSaint: string : Date du vendredi saint au format MM/DD
		i : int : itérations de boucles
	*/

	public static string Ascension(int pAnnee)
	{
		//Déclarations :
		string ascension;
		int moisVendrediSaint;
		int jourVendrediSaint;
		string vendrediSaint;
		int i;

		//Initialisations :
		vendrediSaint = VendrediSaint(pAnnee);

		//Extractions :
		moisVendrediSaint = int.Parse(vendrediSaint.Substring(0,2));
		jourVendrediSaint = int.Parse(vendrediSaint.Substring(3,2));

		//Calculs :
		for(i=1 ; i<=41; i++)
		{
			jourVendrediSaint++;
			if (jourVendrediSaint>JoursMax(moisVendrediSaint, EstBissextile(pAnnee)))
			{
				moisVendrediSaint+=1;
				jourVendrediSaint =1;
			}
		}

		//Mise au format :
		if(jourVendrediSaint <10)
		{
			ascension = "0"+moisVendrediSaint.ToString()+"/"+"0"+jourVendrediSaint.ToString();
		}
		else
		{
			ascension = "0"+moisVendrediSaint.ToString()+"/"+jourVendrediSaint.ToString();
		}

		//Retour :
		

		return ascension;



	}




//Définition de LundiPaques :
	/*
	LundiPaques : fonct : string : Date du lundi de paques au format MM/DD

	Paramètres :
		pAnnee : int 

	Retour :
		lundiPaques : string : Date du lundi de paques au format MM/DD

	Locales :
		jourVendrediSaint : int
		moisVendrediSaint : int
		vendrediSaint: string : Date du vendredi saint au format MM/DD
		i : int : itérations de boucles
	*/

	public static string LundiPaques(int pAnnee)
	{
		//Déclarations :
		string lundiPaques;
		int moisVendrediSaint;
		int jourVendrediSaint;
		string vendrediSaint;
		int i;

		//Initialisations :
		vendrediSaint = VendrediSaint(pAnnee);

		//Extractions :
		moisVendrediSaint = int.Parse(vendrediSaint.Substring(0,2));
		jourVendrediSaint = int.Parse(vendrediSaint.Substring(3,2));

		//Calculs :
		for(i=1 ; i<=3; i++)
		{
			jourVendrediSaint++;
			if (jourVendrediSaint>JoursMax(moisVendrediSaint, EstBissextile(pAnnee)))
			{
				moisVendrediSaint+=1;
				jourVendrediSaint =1;
			}
		}

		//Mise au format :
		if(jourVendrediSaint <10)
		{
			lundiPaques = "0"+moisVendrediSaint.ToString()+"/"+"0"+jourVendrediSaint.ToString();
		}
		else
		{
			lundiPaques = "0"+moisVendrediSaint.ToString()+"/"+jourVendrediSaint.ToString();
		}

		//Retour :
		

		return lundiPaques;



	}




//Définition de Quantieme :
	/*
	Quantieme : fonct : int : Retroune le quantieme d'un jour dont on connait la date

	Paramètres :
		pJour : int 
		pMois : int 
		pAnnee : int


	Retour :
		quantieme : int : Numero du jour de l'annee

	Locales :
		mois : int : Mois entrain d'etre parcouru.

	*/

	public static int Quantieme(int pJour, int pMois, int pAnnee)
	{
		//Déclarations :
		int quantieme;
		int mois;

		//Initialisations:
		quantieme = pJour;

		//Calculs :
		for(mois = 1; mois <pMois; mois++)
		{
			quantieme += JoursMax(mois, EstBissextile(pAnnee));
		}

		//Retour :
		return quantieme;

	}






//Declaration de la EstBissextile :
	/*
	EstBissextile : fonct : bool : Verifie si l'annee entrée est bissextile et retourne True si c'est le cas, False sinon.

	Parametres : 
		pAnnee : int : annee à tester

	Retour :
		bissextile : bool : caractere bissextile ou non de l'annee entrée

	Local:
	*/

	public static bool EstBissextile(int pAnnee)
	{
		bool bissextile = false;
		if((pAnnee % 4 == 0 && pAnnee % 100 != 0)||pAnnee % 400==0)
		{
			bissextile = true;
		}
		return bissextile;
	}





	//Declaration de la JoursMax :
	/*
	JoursMax : fonct : int : Retourne le nombre de jours d'un mois

	Parametres : 
		pMois : int 
		pEstBissextile : bool

	Retour :
		nbrJours : int

	Local : 
	*/

	public static int JoursMax(int pMois, bool pEstBissextile)
	{
		int nbrJours;

		//On test le mois de février :
		if(pMois == 2 && pEstBissextile)
		{
			nbrJours =29;
		}
		else if(pMois == 2 && !pEstBissextile)
		{
			nbrJours = 28;
		}

		//On test maintenant les mois jusqu'à juillet inclus :
		else if (pMois <=7)
		{
			if (pMois % 2 == 0)
			{
				nbrJours = 30;
			}
			else
			{
				nbrJours = 31;
			}
		}

		//On termine par les autres mois:
		else
		{
			if (pMois % 2 == 0)
			{
				nbrJours =31;
			}
			else
			{
				nbrJours=30;
			}
		}

		return nbrJours;

		
	}






//Définition de NomJour :
	/*
	NomJour : fonct : string : Retourne le nom du jour de la semaine 

	Paramètre :
		pNbrJourSem : int : Numéro correspondant au jour de la semaine 
	
	Retour :
		nomJour : string : Nom du jour de la semaine.

	Locales :

	*/

	public static String NomJour(int pNbrJour)
	{
		//Déclaration :
		string nomJour;

		//Tests:
		if (pNbrJour == 0)
		{
			nomJour = "Dimanche";
		}
		else if (pNbrJour == 1)
		{
			nomJour = "Lundi";
		}
		else if (pNbrJour == 2)
		{
			nomJour = "Mardi";
		}
		else if (pNbrJour == 3)
		{
			nomJour = "Mercredi";
		}
		else if (pNbrJour == 4)
		{
			nomJour = "Jeudi";
		}
		else if (pNbrJour == 5)
		{
			nomJour = "Vendredi";
		}
		else
		{
			nomJour = "Samedi";
		}

		//Retour :
		return nomJour;

	}






//Définition de NumJourSem:
	/*
	NumJourSem : fonct : int : Retourne le numéro correspondant au jour de la semaine

	Paramètres :
		pMois : int : Numéro correspondant au mois.
		pAnnee : int : Numéro de l'année.
		pJour : int : Jour du mois.

	Retour :
		numJourSem : int : Numéro correspondant au jour de la semaine ( entre 0 et 6)

	Locales :
		z : int : Variable calculée à partir de l'annee et du mois.

	*/

	public static int NumJourSem(int pJour, int pMois, int pAnnee)
	{
		//Déclarations :
		int numJourSem;
		int z;

		//Initialisation:
		if (pMois<3)
		{
			z= pAnnee - 1;
		}
		else 
		{
			z= pAnnee;
		}

		//Calculs :
		if (pMois >= 3)
		{
			numJourSem = (((23 * pMois)/ 9) + pJour + 4 + pAnnee + (z/4) - (z/100) + (z/400) - 2) % 7;
		}

		else 
		{
			numJourSem= (((23 * pMois)/ 9) + pJour + 4 + pAnnee + (z/4) - (z/100) + (z/400)) % 7;
		}

		//Retour :
		return numJourSem;
	}




//Définition de NomMois :
	/*
	NomMois : fonct : string : Retourne le nom du mois de l'année

	Paramètre :
		pMois : int : Numéro correspondant au mois de l'annee.
	
	Retour :
		nomMois : string : Nom du mois de l'année

	Locales :

	*/

	public static String NomMois(int pMois)
	{
		//Déclaration :
		string nomMois;

		//Tests:
		if (pMois == 1)
		{
			nomMois = "Janvier";
		}
		else if (pMois == 2)
		{
			nomMois = "Fevrier";
		}
		else if (pMois == 3)
		{
			nomMois = "Mars";
		}
		else if (pMois == 4)
		{
			nomMois = "Avril";
		}
		else if (pMois == 5)
		{
			nomMois = "Mai";
		}
		else if (pMois == 6)
		{
			nomMois = "Juin";
		}
		else if (pMois == 7)
		{
			nomMois = "Juillet";
		}
		else if (pMois == 8)
		{
			nomMois = "Aout";
		}
		else if (pMois == 9)
		{
			nomMois = "Septembre";
		}
		else if (pMois == 10)
		{
			nomMois = "Octobre";
		}
		else if (pMois == 11)
		{
			nomMois = "Novembre";
		}
		else 
		{
			nomMois = "Decembre";
		}

		//Retour :
		return nomMois;

	}




//Définition de Affichage :
	/*
	Affichage : proc : Affiche le nom du jour de la semaine, le quantième du jour et s'il s'agit d'un jour férié ou non, le tout formaté.

	Paramètres :
		pJour : string 
		pMois : string
		pAnnee : string

	Locales :



	*/

	public static void Affichage(string pJour, string pMois, string pAnnee)
	{	
		//On saute deux lignes :
		Console.WriteLine("");
		Console.WriteLine("");

		//On affiche la date sélectionnée :
		Console.WriteLine("	Le "+pJour+" "+NomMois(int.Parse(pMois))+" "+pAnnee+" :");

		//On saute une ligne :
		Console.WriteLine("");

		//On affiche le nom du jour :
		Console.WriteLine("		"+NomJour(NumJourSem(int.Parse(pJour), int.Parse(pMois), int.Parse(pAnnee))));

		//On saute une ligne :
		Console.WriteLine("");

		//On affiche le quantième du jour :
		Console.WriteLine("		Quantieme : "+Quantieme(int.Parse(pJour), int.Parse(pMois), int.Parse(pAnnee)));

		//On saute une ligne :
		Console.WriteLine("");

		//On affiche le caractère férié ou non du jour :
		Console.WriteLine("		"+EstFerie(pJour, pMois, pAnnee));

		//On saute deux lignes :
		Console.WriteLine("");
		Console.WriteLine("");

	}










}