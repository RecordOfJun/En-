package view;
import javax.swing.*;
import java.awt.*;
public class mainFrame extends JFrame {
	Container container=getContentPane();
	LoginPanel loginPanel=new LoginPanel();
	public mainFrame() {
		setFrame();
	}
	
	private void setFrame() {
		setTitle("안녕");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000,630);
		container.add(loginPanel);
		setVisible(true);
	}
}
