package View;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;

public class MainFrame extends JFrame{
	JTextField searchField=new JTextField();
	private boolean isClicked=false;
	
	private Container mainContainer=getContentPane();
	public void MainForm() {
		setTitle("이미지 검색");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000, 500);
	}
	
	public void firstForm() {
		JPanel imagePanel=new JPanel();
		JPanel searchPanel=new JPanel(new FlowLayout());
		JPanel recordPanel=new JPanel();
		JLabel googleLabel=new JLabel(new ImageIcon("images/googleLabel.png"));
		JButton searchButton=new JButton(new ImageIcon("images/searchIcon.PNG"));
		JButton recordButton=new JButton("검색기록");
		searchField.setText("검색어를 입력해주세요.");
		mainContainer.removeAll();
		mainContainer.setBackground(Color.white);
		imagePanel.setBackground(Color.white);
		searchPanel.setBackground(Color.white);
		recordPanel.setBackground(Color.white);
		searchButton.setBackground(Color.white);
		searchButton.setBackground(Color.white);
		searchButton.setPreferredSize(new Dimension(40,40));
		searchField.setPreferredSize(new Dimension(300,40));
		imagePanel.add(googleLabel);
		searchPanel.add(searchField);
		searchPanel.add(searchButton);
		recordPanel.add(recordButton);
		searchField.addMouseListener(new SearchFieldMouseEvent());
		searchField.addKeyListener(new SearchFieldKeyEvent());
		searchButton.addMouseListener(new SearchButtonEvent());
		mainContainer.setLayout(new BorderLayout());
		mainContainer.add(imagePanel,BorderLayout.NORTH);
		mainContainer.add(searchPanel,BorderLayout.CENTER);
		mainContainer.add(recordPanel,BorderLayout.SOUTH);
		setVisible(true);
	}
	
	private class SearchFieldMouseEvent extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			if(isClicked==false) {
				SetTextAndClicked("",true);
			}
		}
	}
	private class SearchFieldKeyEvent extends KeyAdapter{
		public void keyPressed(KeyEvent e) {
			if(isClicked==false) {
				SetTextAndClicked("",true);
			}
			if(e.getKeyChar()=='\n') {
				if(searchField.getText().equals("")) {
					SetTextAndClicked("검색어가 비어있습니다.",false);
				}
				else {//내용 있을 때 검색 시
					
				}
			}
		}
	}
	private class SearchButtonEvent extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			if(isClicked==false||searchField.getText().equals("")) {
				SetTextAndClicked("검색어가 비어있습니다.",false);
			}
			else {//내용 있을 때 검색 시
				
			}
		}
	}
	private void SetTextAndClicked(String text,boolean isClicked) {
		searchField.setText(text);
		this.isClicked=isClicked;
	}
}
