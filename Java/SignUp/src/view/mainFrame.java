package view;
import javax.swing.*;

import view.mainFrame.signUpButtonAction;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class mainFrame extends JFrame {
	private Container container=getContentPane();
	private LoginPanel loginPanel=new LoginPanel();
	private SignUpPanel signUpPanel=new SignUpPanel();
	public mainFrame() {
		setFrame();
		loginPanel.singUpButton.addActionListener(new signUpButtonAction());
		signUpPanel.a.addActionListener(new backButtonAction());
	}
	
	private void setFrame() {
		setTitle("안녕");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000,638);
		setResizable(false);
		container.add(loginPanel);
		setVisible(true);
	}
	
	public class signUpButtonAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			container.remove(loginPanel);
			container.add(signUpPanel);
			signUpPanel.repaint();
			signUpPanel.revalidate();
			container.repaint();
			revalidate();
			
		}
		
	}
	public class backButtonAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			container.remove(signUpPanel);
			container.add(loginPanel);
			repaint();
			revalidate();
			signUpPanel.setVisible(true);
		}
		
	}
}
