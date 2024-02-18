package jaxrs.resources;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import jaxrs.entities.Employe;
import jaxrs.filtres.Secured;


//@Secured
@Path("employes")
public class GestionEmploye {
	static List<Employe> employes = new ArrayList<Employe>();

	@Secured
	@POST
	@Consumes(MediaType.APPLICATION_XML)
	public String ajouterEmploye(Employe employe) {
		if (employes.add(employe))
			return "Employe ajouté";
		else
			return "Employe non ajouté";
	}
	
	
	@GET
	@Produces("application/xml")
	public List<Employe> afficherListeEmployes() {
		if (employes==null) 
			return null;
		return employes;
	}
	
	@GET
	@Path("{cin}")
	@Produces("application/xml")
	public Employe chercherEmploye(@PathParam("cin") String cin) {
		int index = this.getIndexOfEmployeByCin(cin);
		if (index != -1) {
			return employes.get(index);
		}
		return null;
	}
	
	@PUT
	@Consumes("application/xml")
	public String modifierEmploye(Employe employe) {
		int index = this.getIndexOfEmployeByCin(employe.getCin());
		if (index != -1) {
			employes.set(index, employe);
			return "update successful";
		} else {
			return "update unsuccessful"+index;
		}
	}
	

	@DELETE
	@Path("employe/delete/{Cin}")
	public String deleteEmploye(@PathParam("Cin") String cin) {
		int index = this.getIndexOfEmployeByCin(cin);

		if ((index != -1) && (employes.remove(index) != null))
			return "Employe supprim� avec succ�s";
		return "Supression non effectu�e";

	}

	
	//utilitaire //fonction interne
	public int getIndexOfEmployeByCin(String CIN) {
		for (Employe emp : employes) {
			if (emp.getCin().equals(CIN)) {
				return employes.indexOf(emp);
			}
		}
		return -1;
	}
	
	
		
	
	

}
