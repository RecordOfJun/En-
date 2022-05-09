package View;
import Controller.Search;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class MainFrame extends JFrame{
	//전역이 좀 많은거 같은데(패널들 따로 클래스 관리)
	public JTextField searchField=new JTextField();
	private JButton searchButton=new JButton(new ImageIcon("images/searchIcon.PNG"));
	private JButton recordButton=new JButton("검색기록");
	private JButton backButton=new JButton(new ImageIcon("images/backArrow.PNG"));
	private JPanel searchMorePanel=new JPanel(new FlowLayout());
	private JPanel centerPanel=new JPanel(new FlowLayout());
	private String[] quantities= {"10","20","30"};
	private JComboBox quantityBox=new JComboBox(quantities);
	public boolean isClicked=false;
	FlowLayout northLayout=new FlowLayout();
	private JPanel northPanel=new JPanel(northLayout);
	private Container mainContainer=getContentPane();
	
	public void ShowForm() {
		setTitle("이미지 검색");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(1000, 800);
		setResizable(false);
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
		quantityBox.addActionListener (new ActionListener () {
		    public void actionPerformed(ActionEvent e) {
		    	JComboBox comboBox = (JComboBox) e.getSource(); 
                int index = comboBox.getSelectedIndex()+1;
                ShowResult(index*10,imageArray);
		    }
		});
		quantityBox.setSelectedIndex(0);
		mainContainer.removeAll();
		searchMorePanel.setBackground(Color.white);
		mainContainer.setBackground(Color.white);
		InitBackButton();
		northPanel.add(backButton);
		mainContainer.setLayout(new BorderLayout());
		mainContainer.add(northPanel,BorderLayout.NORTH);
		searchMorePanel.add(searchField);
		searchMorePanel.add(searchButton);
		searchMorePanel.add(quantityBox);
		northPanel.add(backButton);
		ShowResult(10,imageArray);
		setVisible(true);
	}
	
	private void ShowResult(int maxLength,ImageIcon[] imageArray) {
		centerPanel.removeAll();
		GridLayout resultLayout;
		if(maxLength==30)
			resultLayout=new GridLayout(6,5);
		else if(maxLength==20)
			resultLayout=new GridLayout(4,5);
		else
			resultLayout=new GridLayout(2,5);
		JPanel resultPanel=new JPanel(resultLayout);
		centerPanel.setBackground(Color.white);
		int length=maxLength;
		if(imageArray.length<maxLength) 
			length=imageArray.length;
		for(int count=0;count<length;count++) {
			System.out.println(count);
			JButton resultImage=new JButton(new ImageIcon(imageArray[count].getImage().getScaledInstance(100, 100, Image.SCALE_SMOOTH)));
			resultImage.setSize(100, 100);
			resultImage.addMouseListener(new resultAdapter(imageArray[count]));
			resultPanel.add(resultImage);
		}
		//배치는 나중에
		centerPanel.add(searchMorePanel);
		centerPanel.add(resultPanel);
		mainContainer.add(centerPanel,BorderLayout.CENTER);
		setVisible(false);
		setVisible(true);
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
