package view;
import javax.swing.*;
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
		signUpPanel.backButton.addActionListener(new backButtonAction());
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
		}
	}
	
}
