/* Classe permettant d'écrire des informations dans un fichier de journalisation.
 * 
 * Créé par Charles Lachance
 */ 
//<Charles Lachance>
using System;
using System.IO;

namespace TP3
{
  class Logger
  {
    //Instance unique de la classe
    private static Logger logger = null;

    /// <summary>
    /// Constructeur par défaut privé pour éviter la création
    /// de plus d'une instance.
    /// </summary>
    private Logger()
    {
      
    }

    /// <summary>
    /// Destructeur ajoutant une ligne signifiant la fin de la journalisation.
    /// </summary>
    ~Logger()
    {
      try
      {
        //On ajoute la ligne signifiant la fin de la journalisation
        File.AppendAllText("log.txt", "---------------------------------------------\r\n");
      }
      catch (Exception ex) //Erreur
      {
        //On affiche l'erreur à la console
        Console.WriteLine("Logger : " + ex.Message);
      }
    }

    /// <summary>
    /// Retourne l'instance unique du logger, la créant au préalable si elle
    /// n'existe pas encore.
    /// </summary>
    /// <returns>Retourne l'instance unique du logger</returns>
    public static Logger GetInstance()
    {
      //si le logger n'as pas encore été créé...
      if (logger == null)
        logger = new Logger(); //On le crée
      return logger;
    }

    /// <summary>
    /// Ajoute un message dans le fichier de journalisation.
    /// </summary>
    /// <param name="text">Le message à ajouter au fichier de journalisation</param>
    public void Log(string text)
    {
      try
      {
        //On ajoute le message daté au fichier de journaliation
        File.AppendAllText("log.txt", DateTime.Now.ToString() + ":\t" + text + "\r\n");
      }
      catch (Exception ex) //Erreur
      { 
        //On affiche à la console le message que l'on souhaitait journaliser
        Console.WriteLine(text);
        //On affiche à la console le message d'erreur
        Console.WriteLine("Logger : " + ex.Message);
      }
    }
  }
}
//</Charles Lachance>