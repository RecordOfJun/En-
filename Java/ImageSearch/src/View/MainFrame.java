package View;
import Controller.Search;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;

public class MainFrame extends JFrame{
	public JTextField searchField=new JTextField();
	private JButton searchButton=new JButton(new ImageIcon("images/searchIcon.PNG"));
	private JButton recordButton=new JButton("검색기록");
	private JButton backButton=new JButton(new ImageIcon("images/backArrow.PNG"));
	public boolean isClicked=false;
	private Container mainContainer=getContentPane();
	
	public void ShowForm() {
		setTitle("이미지 검색");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000, 500);
	}
	//검색 폼
	public void SetMainForm() {
		setVisible(false);
		JPanel imagePanel=new JPanel();
		JPanel searchPanel=new JPanel(new FlowLayout());
		JPanel recordPanel=new JPanel();
		JLabel googleLabel=new JLabel(new ImageIcon("images/googleLabel.png"));
		isClicked=false;
		searchField.setText("검색어를 입력해주세요.");
		mainContainer.removeAll();
		mainContainer.setBackground(Color.white);
		imagePanel.setBackground(Color.white);
		searchPanel.setBackground(Color.white);
		recordPanel.setBackground(Color.white);
		searchButton.setBackground(Color.white);
		searchButton.setPreferredSize(new Dimension(40,40));
		searchField.setPreferredSize(new Dimension(300,40));
		imagePanel.add(googleLabel);
		searchPanel.add(searchField);
		searchPanel.add(searchButton);
		recordPanel.add(recordButton);
		mainContainer.setLayout(new BorderLayout());
		mainContainer.add(imagePanel,BorderLayout.NORTH);
		mainContainer.add(searchPanel,BorderLayout.CENTER);
		mainContainer.add(recordPanel,BorderLayout.SOUTH);
		setVisible(true);
	}
	public void addTextMouseListner(MouseListener buttonListener) {
		searchField.addMouseListener(buttonListener);
	}
	public void addTextKeyListner(KeyListener buttonListener) {
		searchField.addKeyListener(buttonListener);
	}
	public void addSearchButtonListner(ActionListener buttonListener) {
		searchButton.addActionListener(buttonListener);
	}
	//검색결과 보여주는 폼
	public void SetResultForm() {
		FlowLayout northLayout=new FlowLayout();
		northLayout.setAlignment(FlowLayout.LEFT);
		JPanel northPanel=new JPanel(northLayout);
		setVisible(false);
		mainContainer.removeAll();
		mainContainer.setBackground(Color.white);
		backButton.setBackground(Color.white);
		northPanel.setBackground(Color.white);
		backButton.setSize(50, 50);
		backButton.setBorderPainted(false);
		backButton.setFocusPainted(false);
		backButton.setContentAreaFilled(false);
		northPanel.add(backButton);
		mainContainer.setLayout(new BorderLayout());
		mainContainer.add(northPanel,BorderLayout.NORTH);
		setVisible(true);
	}
	public void addBackButtonListner(ActionListener buttonListener) {
		backButton.addActionListener(buttonListener);
	}
}
