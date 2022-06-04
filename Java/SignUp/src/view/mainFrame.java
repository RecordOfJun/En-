package view;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class mainFrame extends JFrame {
	public Container container=getContentPane();
	public LoginPanel loginPanel=new LoginPanel();
	public SignUpPanel signUpPanel=new SignUpPanel();
	public UserPanel userPanel=new UserPanel();
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
	
	public void setUserPanel() {
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
