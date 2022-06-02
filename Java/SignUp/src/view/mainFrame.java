package view;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
public class mainFrame extends JFrame {
	private Container container=getContentPane();
	private LoginPanel loginPanel=new LoginPanel();
	public mainFrame() {
		setFrame();
	}
	
	private void setFrame() {
		setTitle("안녕");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000,638);
		setResizable(false);
		container.add(loginPanel);
		setVisible(true);
	}
}
