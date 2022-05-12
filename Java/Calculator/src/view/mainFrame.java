package view;
import java.awt.Container;

import javax.swing.*;
import javax.swing.event.*;
public class mainFrame extends JFrame {
	private buttonPanel buttons=new buttonPanel();
	private Container container=getContentPane();
	
	public void loadFrame() {
		setTitle("계산기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.add(buttons);
		setSize(400, 900);
		setVisible(true);
	}
	
}
