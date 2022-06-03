package main;

import java.awt.Desktop;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;

import controller.AdressSearching;
import controller.MainController;

public class SignUpProgramm {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//MainController mainController=new MainController();
		AdressSearching a=new AdressSearching();
		a.getAdresses("고산로 539번길");
	}

}
