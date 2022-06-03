package controller;

import javax.swing.JButton;
import model.UserDAO;
import javax.swing.*;
import java.awt.*;
import view.AdressFrame;
import view.Dialog;
import view.SignUpPanel;
import view.mainFrame;
import view.mainFrame.signUpButtonAction;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class MainController {
	private mainFrame frame;
	private Entrance entrance;
	private AccountCreation accountCreation;
	private AccountFinding accountFinding;
	private JButton loginButton;
	private JButton completeButton;
	private AdressSearching adressSearching;
	
	public MainController() {
		this.frame=new mainFrame();
		this.accountCreation=new AccountCreation();
		this.accountFinding=new AccountFinding();
		this.loginButton=frame.loginPanel.loginButton;
		this.entrance=new Entrance();
		this.completeButton=frame.signUpPanel.completeButton;
		this.adressSearching=new AdressSearching();
		setButton();
	}
	
	private void setButton() {
		loginButton.addActionListener(new loginAction());
		completeButton.addActionListener(new completeAction());
		frame.signUpPanel.idCheckButton.addActionListener(new idOverlapAction());
		frame.signUpPanel.personalCheckButton.addActionListener(new personalOverlapAction());
		frame.signUpPanel.adressFindButton.addActionListener(new addressFindAction());
	}
	
	public class loginAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			String idAndPw=frame.loginPanel.getIdAndPw();
			if(entrance.isExistedID(idAndPw))
				frame.setUserPanel();
		}
	}
	
	public class completeAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			ArrayList<String> userData=frame.signUpPanel.getInsertData();
			if(accountCreation.isCorrectData(frame.signUpPanel.isCheckedID, frame.signUpPanel.isCheckedPersonal, userData)) {
				accountCreation.addAccount(userData);
				frame.container.remove(frame.signUpPanel);
				frame.container.add(frame.loginPanel);
				frame.repaint();
				frame.revalidate();
			}
		}
	}
	
	public class idOverlapAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			frame.signUpPanel.isCheckedID=accountCreation.isCorrectID(frame.signUpPanel.getInsertData().get(0));
		}
	}
	
	public class personalOverlapAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			frame.signUpPanel.isCheckedPersonal=accountCreation.isCorrectPersonal(frame.signUpPanel.getInsertData().get(4));
		}
	}
	
	public class addressFindAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			AdressFrame adressFrame=new AdressFrame();
			adressFrame.searchButton.addActionListener(new adressSearchAction(adressFrame));
		}
	}
	
	public class adressSearchAction implements ActionListener{
		AdressFrame adressFrame;
		public adressSearchAction(AdressFrame adressFrame) {
			this.adressFrame=adressFrame;
		}
		public void actionPerformed(ActionEvent e) {
			adressFrame.mainBox.removeAll();
			ArrayList<String> adress=adressSearching.getAdresses(adressFrame.adressField.getText());
			for(int count=0;count<adress.size();count+=2) {
				adressFrame.addButton(adress.get(count),adress.get(count+1),frame.signUpPanel.adressField);
			}
			adressFrame.repaint();
			adressFrame.revalidate();
		}
	}
}
