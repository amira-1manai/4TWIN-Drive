########################################################### LINQ ###########################################################

												Get5Chemical (double price) ; 
							retourne les cinq premiers produits chemical qui ont un prix inférieur à price.
							
List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}

 public IEnumerable<Product> Get5Chemical(double price)
	{
		IEnumerable<Product> prodQuery = 
	   (from prod in products 
		where prod is Chemical && (prod.Price > price) 
		select prod)
		.Take(5);
		return prodQuery;
	}
		
		
														GetProductPrice(double price) :
							retourne les produits qui ont un prix supérieur à price en ignorant les 2 premiers produits.
	
List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}

public IEnumerable<Product> GetProductPrice(double price)
	{
	IEnumerable<Product> prodQuery = 
	(from prod in products 
	where (prod.Price > price) 
	select prod )
	.Skip(2);
	return prodQuery;
	}
		
															GetAveragePrice() :
												retourne le prix MOYEN de tous les produits
												
List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}

public double GetAverage()
	{
	var prodqQuery = 
	(from prod in products 
	select prod.Price)
	.Average();
	return prodqQuery;
	}
	
															GetMaxPrice() :  
													retourne le produit de MAX prix .

List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}

public Product GetMaxPrice()
	{
	var prodqQuery = 
	(from prod in products 
	select prod.Price)
	.Max();
	return prodqQuery;
	}

														GetCountProduct(string city) : 
											retourne le nombre de produits de type chemical d’un city.
											
List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}

public double CountProduct(string city)
{
	var query = 
	from prod in products 
	where prod is Chemical && ((Chemical)prod).City == city 
	select prod;
	return query.Count();
}

															GetChemicalCity() : 
										retourne la liste des produits chemical ordonnés par city
										
List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}
						
public IEnumerable<Product> GetChemicalCity()
{
	var query = 
	from prod in products 
	where prod is Chemical orderby ((Chemical)prod).City 
	select prod;
	return query;
}

															GetChemicalGroupByCity() : 
											affiche la liste des produits chemical ordonnés et groupé par city..

List<Product> products = new List<Product>();
public ManageProvider(List<Product> products){}

public void GetChemicalGroupByCity()
{
	var query = 
	from prod in products 
	where prod is Chemical orderby ((Chemical)prod).City group ((Chemical)prod) by ((Chemical)prod).City;

	foreach(var groupingPrd in query)
	{
		Console.WriteLine("City : " + groupingPrd.Key);

		foreach (var prod in groupingPrd)
		{
			Console.WriteLine("Nom Produit : " + prod.Name);
		}
	}
}

														GetProviderByName(string name) : 
											retourne la liste des providers dont le username contient name.

List<Provider> providers = new List<Provider>();
public ManageProvider(List<Provider> providers){}

public IEnumerable<Provider> GetProviderByName(string name)
{
	var query = 
	from prov in providers 
	where prov.UserName.ToUpper().Contains(name.ToUpper()) 
	select prov;
	return query;
}

													GetFirstProviderByName(string name) : 
										retourne le premier provider dont le username commence par name.

List<Provider> providers = new List<Provider>();
public ManageProvider(List<Provider> providers){}

public Provider GetFirstProvideByName(string name)
{
	var query = 
	from prov in providers 
	where prov.UserName.ToUpper().StartsWith(name.ToUpper()) 
	select prov;
	return query.First();
}
											GetProviderById(int id) : 
									retourne le seul provider d’identifiant id.

List<Provider> providers = new List<Provider>();
public ManageProvider(List<Provider> providers){}

public Provider GetProviderById(int id)
{
	var query = 
	from prov in providers 
	where prov.Id == id 
	select prov;
	return query.Single();
}

												UpperName(Product product) : 
											met en majuscule le nom d’un product..
	
	public static void UpperName(Product product)
{
   product.Name = product.Name.ToUpper();
}
									InCategory(Product product, Category category) : 
						retourne true si un produit appartient à la catégorie passée en paramètre.
						
 public static bool InCategory(Product product, Category category)
        {
            return product.Category.Name == category.Name;
        }