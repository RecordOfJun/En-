package View;

import java.awt.Container;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;

public class MainFrame extends JFrame{
	private Container mainContainer=getContentPane();
	public void MainForm() {
		setTitle("이미지 검색");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		mainContainer.setLayout(new BorderLayout());
		setSize(1000, 500);
		setVisible(true);
	}
	
	public void firstForm() {
		JLabel label=new JLabel("Hello");
		mainContainer.add(label);
	}
}
