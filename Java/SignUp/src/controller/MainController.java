package controller;

import javax.swing.JButton;
import model.UserDAO;
import javax.swing.*;
import java.awt.*;
import view.AdressFrame;
import view.Dialog;
import view.SignUpPanel;
import view.MainFrame;
import view.MainFrame.signUpButtonAction;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class MainController {
	private MainFrame frame;
	private Entrance entrance;
	private AccountCreation accountCreation;
	private JButton loginButton;
	private JButton completeButton;
	private AdressSearching adressSearching;
	
	public MainController() {
		this.frame=new MainFrame();
		this.accountCreation=new AccountCreation();
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
		frame.signUpPanel.adressFindButton.addActionListener(new addressFindAction(frame.signUpPanel.adressField));
		frame.userPanel.revisePanel.adressFindButton.addActionListener(new addressFindAction(frame.userPanel.revisePanel.adressField));
		frame.userPanel.revisePanel.reviseButton.addActionListener(new reviseAction());
	}
	
	public class loginAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			String idAndPw=frame.loginPanel.getIdAndPw();
			if(entrance.isExistedID(idAndPw))
				frame.setUserPanel(idAndPw.split("/")[0],idAndPw.split("/")[1]);
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
	
	public class reviseAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			ArrayList<String> userData=frame.userPanel.revisePanel.getInsertData();
			if(accountCreation.isCorrectData(frame.userPanel.revisePanel.isCheckedID, frame.userPanel.revisePanel.isCheckedPersonal, userData)) {
				UserDAO.getInstance().UpdateUser(userData.get(0), userData.get(1), userData.get(3), userData.get(5), userData.get(6), userData.get(7));
				frame.userPanel.password=userData.get(1);
				Dialog.getInstance().reviseSucess();
				frame.container.remove(frame.userPanel.revisePanel);
				frame.container.add(frame.userPanel);
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
		JTextField addressField;
		public addressFindAction(JTextField addressField) {
			this.addressField=addressField;
		}
		public void actionPerformed(ActionEvent e) {
			AdressFrame adressFrame=new AdressFrame();
			adressFrame.searchButton.addActionListener(new adressSearchAction(adressFrame,addressField));
		}
	}
	
	public class adressSearchAction implements ActionListener{
		AdressFrame adressFrame;
		JTextField addressField;
		public adressSearchAction(AdressFrame adressFrame,JTextField addressField) {
			this.adressFrame=adressFrame;
			this.addressField=addressField;
		}
		public void actionPerformed(ActionEvent e) {
			adressFrame.mainBox.removeAll();
			ArrayList<String> adress=adressSearching.getAdresses(adressFrame.adressField.getText());
			for(int count=0;count<adress.size();count+=2) {
				adressFrame.addButton(adress.get(count),adress.get(count+1),addressField);
			}
			adressFrame.repaint();
			adressFrame.revalidate();
		}
	}
}
