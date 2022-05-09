package View;
import Controller.Search;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class MainFrame extends JFrame{
	//전역이 좀 많은거 같은데
	public JTextField searchField=new JTextField();
	private JButton searchButton=new JButton(new ImageIcon("images/searchIcon.PNG"));
	private JButton recordButton=new JButton("검색기록");
	private JButton backButton=new JButton(new ImageIcon("images/backArrow.PNG"));
	public boolean isClicked=false;
	FlowLayout northLayout=new FlowLayout();
	private JPanel northPanel=new JPanel(northLayout);
	private Container mainContainer=getContentPane();
	
	public void ShowForm() {
		setTitle("이미지 검색");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000, 500);
	}
	//검색 폼
	public void SetMainForm() {
		setVisible(false);
		JPanel labelPanel=new JPanel();
		JPanel searchPanel=new JPanel(new FlowLayout());
		JPanel recordPanel=new JPanel();
		JLabel googleLabel=new JLabel(new ImageIcon("images/googleLabel.png"));
		isClicked=false;
		searchField.setText("검색어를 입력해주세요.");
		mainContainer.removeAll();
		mainContainer.setBackground(Color.white);
		labelPanel.setBackground(Color.white);
		searchPanel.setBackground(Color.white);
		recordPanel.setBackground(Color.white);
		searchButton.setBackground(Color.white);
		searchButton.setPreferredSize(new Dimension(40,40));
		searchField.setPreferredSize(new Dimension(300,40));
		labelPanel.add(googleLabel);
		searchPanel.add(searchField);
		searchPanel.add(searchButton);
		recordPanel.add(recordButton);
		mainContainer.setLayout(new BorderLayout());
		mainContainer.add(labelPanel,BorderLayout.NORTH);
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
	private void InitBackButton() {
		backButton.setBackground(Color.white);
		backButton.setSize(50, 50);
		backButton.setBorderPainted(false);
		backButton.setFocusPainted(false);
		backButton.setContentAreaFilled(false);
		northPanel.setBackground(Color.white);
		northLayout.setAlignment(FlowLayout.LEFT);
	}
	//검색결과 보여주는 폼
	public void SetResultForm(ImageIcon[] imageArray) {
		setVisible(false);
		mainContainer.removeAll();
		mainContainer.setBackground(Color.white);
		InitBackButton();
		northPanel.add(backButton);
		mainContainer.setLayout(new BorderLayout());
		mainContainer.add(northPanel,BorderLayout.NORTH);
		ShowButton(30,imageArray);
		setVisible(true);
	}
	
	private void ShowButton(int maxLength,ImageIcon[] imageArray) {
		GridLayout resultLayout=new GridLayout(6,5);
		JPanel resultPanel=new JPanel(resultLayout);
		JPanel leftPanel=new JPanel();
		JLabel leftLabel=new JLabel("");
		leftLabel.setSize(200, 10);
		JPanel rightPanel=new JPanel();
		resultPanel.setSize(600, 300);
		leftPanel.setSize(200,300);
		leftPanel.setBackground(Color.red);
		rightPanel.setSize(200,300);
		int length=maxLength;
		if(imageArray.length<maxLength) 
			length=imageArray.length;
		for(int count=0;count<length;count++) {
			System.out.println(count);
			JButton resultImage=new JButton(imageArray[count]);
			resultImage.setSize(100, 100);
			resultImage.addMouseListener(new resultAdapter(imageArray[count]));
			resultPanel.add(resultImage);
		}
		//배치는 나중에
		mainContainer.add(leftPanel,BorderLayout.WEST);
		mainContainer.add(resultPanel,BorderLayout.CENTER);
		mainContainer.add(rightPanel,BorderLayout.EAST);
	}
	
	public void addBackButtonListner(ActionListener buttonListener) {
		backButton.addActionListener(buttonListener);
	}
	class resultAdapter extends MouseAdapter {
		ImageIcon image;
		public resultAdapter(ImageIcon image) {
			this.image=image;
		}
		public void mouseClicked(MouseEvent e) {
			if(e.getClickCount()==2&&!e.isConsumed()) {
				Enlargement enlargement=new Enlargement(image);
				enlargement.ShowForm();
			}
		}
	}
}
