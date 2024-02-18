   
############################################################ SERVICE ############################################################

Dans l'interface IService :

   public interface IServicePlan : IEntityService<Plan>
    {
        public float CoutTotalPlan(Plan p);
    }

Dans la classe service :

	 public class ServicePlan : EntityService<Plan>, IServicePlan
    {
        public ServicePlan(IUnitOfWork utwk, IRepositoryBase<Plan> repository) : base(utwk, repository)
        {
        }

        //4
        public float CoutTotalPlan(Plan p)
        {
            float sum = 500 + p.NombrePieces * 50;
            if (p.Architecte.NombresAnneesExperiences > 5)
                sum += 200;
            if (p.Surface > 200)
                sum += 100;

            return sum;
        }

    }
---------------------------------------------------------------------------------------------------------------------------------------------
									
									public int NbreDossierParSpecialite(Specialite specialite)
												nombre de Dossiers par spécialité

Dans l'interface IServiceDossier :
public int NbreDossierParSpecialite(Specialite specialite);
							
Dans la classe serviceDossier :												
public int NbreDossierParSpecialite(Specialite specialite)
{
return this.GetMany(d => d.Avocat.SpecialiteFK==specialite.id).Count();											
}

---------------------------------------------------------------------------------------------------------------------------------------------
							
										public int NbreProjetsEnCours(Architecte a)
							retourner le nombre de projets en cours d’un Architecte donné.

Dans l'interface IServiceArchitecte :
public int NbreProjetsEnCours(Architecte a);
							
Dans la classe serviceArchitecte :							
public int NbreProjetsEnCours(Architecte a)
{
	return a.Plans.Where(p => p.Etat.Equals(Etat.Encours)).Count(); //Etat c'est une Enumeration
}

---------------------------------------------------------------------------------------------------------------------------------------------

												public int NbreProjetsAnnee(Architecte a)
							retourner le nombre de projets Approuvés d’un architecte pendant l’année courante.
							
Dans l'interface IServiceArchitecte :
public int NbreProjetsAnnee(Architecte a);
							
Dans la classe serviceArchitecte :							
public int NbreProjetsAnnee(Architecte a)
{
	return a.Plans.Where(p => p.DateDebut.Year == DateTime.Now.Year && p.Etat.Equals(Etat.Approuvé)).Count();
}

---------------------------------------------------------------------------------------------------------------------------------------------

											public UnavailableProductsPercentage() 
					retourne le pourcentage des produits dont la quantité est épuisée (Quantity = 0)
					
Dans l'interface IService :
public double UnavailableProductsPercentage();	
					
Dans la classe service :
        public double UnavailableProductsPercentage()
        {
            double a= this.GetMany().Where(p=>p.Quantity==0).Count();
            double a2 = this.GetMany().Count();
            double a3 = (a / a2) * 100;

            return a3;
        }

---------------------------------------------------------------------------------------------------------------------------------------------
		
											public GetProductByName(string name)
											filtrer les produits par nom
Dans l'interface IService :
GetProductByName(string name);

Dans la classe service :	
public IEnumerable<Product> GetProductByName(string name)
{
	return GetMany().Where(p => p.Name.ToLower().Contains(name.ToLower()));
}

---------------------------------------------------------------------------------------------------------------------------------------------

													public specialite MaxAvocat ();
											Retourner la spécialité qui contient le maximum d’avocats.

Dans l'interface IServiceSpecialite : 
public specialite MaxAvocat ();

Dans la classe service :
public specialite MaxAvocat ()
{
	var max = GetMany().Max(s => s.Avocat.Count);
	return GetMany().Where(s => s.Avocat.Count == max).FirtOrDefault();
}
---------------------------------------------------------------------------------------------------------------------------------------------
	
									public IEnumerable<Product> FindMost5ExpensiveProds();	
											retourne les 5 produits les plus chers

Dans l'interface IService :
public IEnumerable<Product> FindMost5ExpensiveProds();	
					
Dans la classe service :
public IEnumerable<Product> FindMost5ExpensiveProds()
{
	return this.GetMany().OrderByDescending(p => p.Price).Take(5);
}
---------------------------------------------------------------------------------------------------------------------------------------------

												public IEnumerable<Client> ClientAvocat(Avocat avocat);
								Retourner les clients, d’un avocat donné, qui ont déposé des dossiers dans les 10 derniers jours.
		
		// Dooiser est la table porteuse
Dans l'interface IServiceDossier : 
public IEnumerable<Client> ClientAvocat(Avocat avocat);

Dans la classe service :
public IEnumerable<Client> ClientAvocat(Avocat avocat) {
	var dossier = GetMany(d => d.AvocatID == avocat.AvocatID)
		.ToList()
		.Where(d => (DateTime.Now- d.DateDepot).Days < 10);
	return tdossier.Select(d => d.Client);
}

---------------------------------------------------------------------------------------------------------------------------------------------
				
							public IEnumerable<Product> GetProdsByCategory(Category category);								 
								retourne les produits pour une categorie passé en paramètre
								
Dans l'interface IService :
public IEnumerable<Product> GetProdsByCategory(Category category);								
								
Dans la classe service :
public IEnumerable<Product> GetProdsByCategory(Category category) {
	return this.GetMany().Where(p => p.Category.Name.ToUpper() == category.Name.ToUpper());
}


---------------------------------------------------------------------------------------------------------------------------------------------

												public void Reduction(Dossier dossier);
						méthode qui prend en paramètre un dossier et fais une réduction de 30%
					sur les frais si l’avocat qui le traite a déjà traité plus que 3 dossiers (ayant un état clos) pour le
												client ayant déposé le dossier.

Dans l'interface IServiceDossier : 
public void Reduction(Dossier dossier);

Dans la classe service :
public void Reduction(Dossier dossier)
{
	var dossier = GetMany(d => d.AvocatID == dossier.AvocatID &&
						       d.clientId == dossier.clientId &&
							   d.Close == True );
							   
	   if(dossier.Count()>3)
		   dossier.Frais = dossier.Frais  * 70/100 ;
}

---------------------------------------------------------------------------------------------------------------------------------------------
								
												 public DeleteOldProducts()  
							supprime les produits dont la date de production a dépassé une année.
Dans l'interface IService :
 public void DeleteOldProducts();
 
Dans la classe service :
 public void DeleteOldProducts()
        {
            IEnumerable<Product> products = this.GetMany().Where(p => (DateTime.Now- p.DateProd).TotalDays>365);
            foreach(Product p in products)
            {
                this.Delete(p);
                Commit();
            }
        }



