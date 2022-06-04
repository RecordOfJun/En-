package view;
import javax.swing.*;

import model.UserDAO;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class MainFrame extends JFrame {
	public Container container=getContentPane();
	public LoginPanel loginPanel=new LoginPanel();
	public SignUpPanel signUpPanel=new SignUpPanel();
	public UserPanel userPanel=new UserPanel(this);
	public MainFrame() {
		setFrame();
		loginPanel.singUpButton.addActionListener(new signUpButtonAction());
		signUpPanel.backButton.addActionListener(new backButtonAction());
		userPanel.logOutButton.addActionListener(new logOutButtonAction());
		userPanel.reviseButton.addActionListener(new setRviseAction());
	}
	
	private void setFrame() {
		setTitle("SignUP");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1280,758);
		setResizable(false);
		container.add(loginPanel);
		container.setBackground(Color.BLACK);
		setVisible(true);
	}
	
	public class signUpButtonAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			signUpPanel.setTextField();
			container.remove(loginPanel);
			container.add(signUpPanel);
			container.repaint();
			revalidate();
			
		}
		
	}
	
	public class backButtonAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			loginPanel.idText.setText("");
			loginPanel.pwText.setText("");
			container.remove(signUpPanel);
			container.add(loginPanel);
			repaint();
			revalidate();
		}
	}
	
	public void setUserPanel(String id,String password) {
		userPanel.id=id;
		userPanel.password=password;
		loginPanel.idText.setText("");
		loginPanel.pwText.setText("");
		container.remove(loginPanel);
		container.add(userPanel);
		repaint();
		revalidate();
	}
	
	public class logOutButtonAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			int reply=Dialog.getInstance().askLogOut();
			if(reply==JOptionPane.YES_OPTION) {
				container.remove(userPanel);
				container.add(loginPanel);
				repaint();
				revalidate();
			}
		}
	}
	
	public class setRviseAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			System.out.println(userPanel.id);
			userPanel.revisePanel.setReviesForm(UserDAO.getInstance().SelectUser(userPanel.id));
			userPanel.revisePanel.backToUserButton.addActionListener(new reviseToUserAction());
			container.remove(userPanel);
			container.add(userPanel.revisePanel);
			repaint();
			revalidate();
		}
	}
	
	public class reviseToUserAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			container.remove(userPanel.revisePanel);
			container.add(userPanel);
			repaint();
			revalidate();
		}
	}
	
}
