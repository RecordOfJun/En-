package view;
import java.awt.BorderLayout;
import java.awt.Container;

import javax.swing.*;
import javax.swing.event.*;
public class mainFrame extends JFrame {
	private buttonPanel buttons=new buttonPanel();
	private Container container=getContentPane();
	private labelPanel calculatings=new labelPanel();
	public void loadFrame() {
		setTitle("계산기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.setLayout(new BorderLayout());
		container.add(calculatings,BorderLayout.CENTER);
		container.add(buttons,BorderLayout.SOUTH);
		setSize(400, 900);
		setVisible(true);
	}
	
}
