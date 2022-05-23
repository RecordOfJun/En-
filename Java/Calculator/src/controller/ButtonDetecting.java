package controller;
import view.ButtonPanel;
import view.TextPanel;
import view.CalculatorFrame;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Font;
import java.awt.event.*;
import javax.swing.*;

import model.NumberList;
import model.State;
import utility.Constant;
public class ButtonDetecting {
	private CalculatorFrame frame;
	private TextPanel textPanel;
	private ButtonPanel buttonPanel;
	private Calculation calculation;
	private NumberProcessing process;
	public State state;
	public NumberList status;
	public ButtonDetecting(){
		frame=new CalculatorFrame();
		status=new NumberList();
		state= new State();
		textPanel=frame.calculatings;
		buttonPanel=frame.buttons;
		calculation=new Calculation(buttonPanel,textPanel,frame.logPanel,state,status);
		process=new NumberProcessing(buttonPanel,textPanel,state,status);
		frame.addWindowListener( new WindowAdapter() {
		    public void windowOpened( WindowEvent e ){
		        buttonPanel.requestFocus();
		    }
		}); 
		frame.addComponentListener(new textResizeListener());
		frame.logPanel.setListener(new logActionListener());
	}
	public void start(){
		frame.loadFrame();
		buttonPanel.appendAdapter(new numberAdapter());
		frame.log.addLogListener(new logButtonListener());
		frame.calculatings.addFrameConvert(new frameclickAdapter());
		addKeyAdapter();
		buttonPanel.requestFocusInWindow();
	}
	public void loadLogFrame() {
		frame.log.addMouseListener(new frameclickAdapter());
		frame.calculatings.addMouseListener(new frameclickAdapter());
		frame.setLogFrame();
	}
	public void loadCalculatorFrame() {
		frame.calculatings.addMouseListener(new frameclickAdapter());
		frame.setCalculatorFrame();
		buttonPanel.requestFocusInWindow();
	}
	public class numberAdapter extends MouseAdapter{
		public void mouseReleased(MouseEvent e) {
			excuteCalculator(getButtonText(e));
		}
	}
	private void excuteCalculator(String character) {
		switchButton(character);
		textPanel.setLogNumberText(calculation.status.getUpFieldText());
	}
	public class numberButtonAdapter extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			String key="";
			switch(e.getKeyCode()) {
				case KeyEvent.VK_ESCAPE:
					key="C";
					break;
				case KeyEvent.VK_DELETE:
					key="CE";
					break;
				case KeyEvent.VK_BACK_SPACE:
					key="\u232B";
					break;
				case KeyEvent.VK_F9:
					key="+/-";
					break;
				case KeyEvent.VK_ENTER:
					key="=";
					break;
			}
			switch(e.getKeyChar()) {
			case '.':
				key=".";
				break;
			case '0':case '1':case '2':case '3':case '4':case '5':case '6':case '7':case '8':case '9':
				key=String.valueOf(e.getKeyChar());
				break;
			case '/':
				key="÷";
				break;
			case'*':
				key="×";
				break;
			case'+':
				key="+";
				break;
			case'-':
				key="-";
				break;
			case'=':
				key="=";
				break;
			}
			if(key!="") {
				buttonPressedEffect(key);
				excuteCalculator(key);
				
			}
				
		}
	}
	private void buttonPressedEffect(String key) {
		for(int count=0;count<buttonPanel.buttons.size();count++) {
			if(buttonPanel.buttons.get(count).getText().equals(key))
				buttonPanel.buttons.get(count).doClick();
		}
	}
	private String getButtonText(MouseEvent e) {
		JButton button=(JButton)e.getSource();
		return button.getText();
	}
	private void switchButton(String character) {
		int type=2;
		switch(character) {
			case"C":
				process.initAll();
				type=2;
				break;
			case"CE":
				process.initLast();
				type=2;
				break;
			case".":
				process.detectDot();
				type=2;
				break;
			case"+/-":
				process.appendSign();
				type=2;
				//직전 숫자만 삭제
				break;
			case"=":
				calculation.detectEqual();
				type=1;
				//직전 숫자만 삭제
				break;
			case"\u232B":
				process.detectBackSpace();
				type=2;
				break;	
			case"÷": case"×": case"+": case"-":
				//직전 숫자만 삭제
				calculation.detectOperator(character);
				type=1;
				break;
			default:
				process.detectNumber(character);
				type=2;
				break;
		}
		textPanel.setPresentNumberText(calculation.status.getNumber(),type);
		resizeText();
	}
	private void addKeyAdapter() {
		buttonPanel.requestFocusInWindow();
		buttonPanel.addKeyListener(new numberButtonAdapter());
		buttonPanel.addFocusListener(new frameFocusAdapter());
		buttonPanel.setFocusable(true);
		buttonPanel.requestFocusInWindow();
	}
	
	public class frameFocusAdapter extends FocusAdapter{
		public void focusLost(FocusEvent e) {
			e.getComponent().setFocusable(true);
			e.getComponent().requestFocusInWindow();
		}
	}
	public class frameclickAdapter extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			loadCalculatorFrame();
		}
	}
	public class logButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			JButton button=(JButton)e.getSource();
			if(button!=null) {
				if(button.getBackground().toString().equals("java.awt.Color[r=230,g=230,b=230]"))
					loadLogFrame();
				else
					loadCalculatorFrame();
			}
		}
	}
	public class logActionListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			JButton button=null;
			if(e.getSource() instanceof JButton) {
				button=(JButton)e.getSource();
			}
			if(button!=null) {
				String text=button.getText().replace("<html><p style=\"text-align:right;\">","").replace("<font size=6>","").replace("</font></p></html>","").replace(",", "");
				text=text.replace(" ", "").replace("\t", " ");
				String[] temporary=text.split("<br>");
				calculation.status.setNumber(temporary[1]);
				calculation.status.setUpField(temporary[0]);
				calculation.state.setIsLog(true);
				calculation.state.setLastType(Constant.TYPE_EQUAL);
				textPanel.setPresentNumberText(calculation.status.getNumber(),2);
				textPanel.setLogNumberText(calculation.status.getUpFieldText());
				loadCalculatorFrame();
				resizeText();
			}
				
		}
	}
	private void resizeText() {
		int size=50;
		textPanel.presentNumber.setFont(new Font("돋움",Font.BOLD,size));
    	while(textPanel.presentNumber.getPreferredSize().getWidth()>textPanel.presentNumber.getWidth()&&textPanel.presentNumber.getWidth()!=0) {
    		textPanel.presentNumber.setFont(new Font("돋움",Font.BOLD,size));
    		textPanel.presentNumber.repaint();
    		textPanel.presentNumber.revalidate();
    		size--;
    	}
	}
	public class textResizeListener extends ComponentAdapter {
        public void componentResized(ComponentEvent e) {
        	resizeText();
        }
	}
}
