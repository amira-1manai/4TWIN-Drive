package com.esprit.busniss;


import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import com.esprit.entities.Logement;
import com.esprit.entities.RendezVous;



public class RendezVousBusiness {
	public static List<RendezVous> listeRendezVous;
	public static LogementBusiness logementMetier=new LogementBusiness();

	public RendezVousBusiness() {
		listeRendezVous=new ArrayList<RendezVous>();
		listeRendezVous.add(new RendezVous(1, "31-10-2015","15:30", logementMetier.getLogementsByReference(4), "55214078"));
		listeRendezVous.add(new RendezVous(2, "20-12-2015","9:00", logementMetier.getLogementsByReference(1), "21300811"));
		listeRendezVous.add(new RendezVous(3, "17-09-2015","9:15", logementMetier.getLogementsByReference(4), "98102102"));
	
	}
	
	public boolean addRendezVous(RendezVous rendezVous){
		int refLogement=rendezVous.getLogement().getReference();
		Logement logement=logementMetier.getLogementsByReference(refLogement);
		if(logement!=null){
			rendezVous.setLogement(logement);
			return listeRendezVous.add(rendezVous);}
		return false;
	}
	public boolean updateRendezVous(int idRendezVous, RendezVous rendezVous){
		for(RendezVous r:listeRendezVous){
			if(r.getId()==idRendezVous){
				int index=listeRendezVous.indexOf(rendezVous);
				Logement logement=logementMetier.getLogementsByReference(rendezVous.getLogement().getReference());
				if(logement!=null){
					listeRendezVous.set(index, rendezVous);
					return true;
				}	
			}
		}
		return false;
	}
	public RendezVous getRendezVousById(int id){
		RendezVous rendezVous=null;
		for(RendezVous r:listeRendezVous){
			if(r.getId()==id)
				rendezVous=r;
		}
		return rendezVous;
	}
	
	public boolean deleteRendezVous(int id){
		Iterator<RendezVous> iterator=listeRendezVous.iterator();
		while(iterator.hasNext()){
			RendezVous r=iterator.next();
			if(r.getId()==id){
				iterator.remove();
				return true;
			}
		}
		return false;
	}

	public List<RendezVous> getListeRendezVous() {
		return listeRendezVous;
	}

	public void setListeRendezVous(List<RendezVous> listeRendezVous) {
		this.listeRendezVous = listeRendezVous;
	}
	
	public List<RendezVous> getListeRendezVousByLogementReference(int reference) {
		List<RendezVous> liste=new ArrayList<RendezVous>();
		for(RendezVous r:listeRendezVous){
			if(r.getLogement().getReference()==reference)
				liste.add(r);
		}
		return liste;
	}
	
	
	

}
