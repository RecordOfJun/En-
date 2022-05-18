package controller;
import view.ButtonPanel;
import view.TextPanel;
import view.CalculatorFrame;

import java.awt.Color;
import java.awt.Component;
import java.awt.event.*;
import javax.swing.*;
import utility.Constant;
public class ButtonDetecting {
	private CalculatorFrame frame;
	private TextPanel textPanel;
	private ButtonPanel buttonPanel;
	private Calculation calculation;
	public ButtonDetecting(){
		frame=new CalculatorFrame();
		textPanel=frame.calculatings;
		buttonPanel=frame.buttons;
		calculation=new Calculation(buttonPanel,textPanel,frame.logPanel);
		frame.addWindowListener( new WindowAdapter() {
		    public void windowOpened( WindowEvent e ){
		        buttonPanel.requestFocus();
		    }
		}); 
		frame.logPanel.setListener(new deleteButtonActionListener());
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
			case'=':
				key="=";
			}
			if(key!="") {
				excuteCalculator(key);
			}
				
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
				calculation.initAll();
				System.out.println("전체 초기화");
				type=2;
				break;
			case"CE":
				calculation.initLast();
				System.out.println("직전 수 초기화");
				type=2;
				break;
			case".":
				calculation.detectDot();
				type=2;
				System.out.println("콤마");
				break;
			case"+/-":
				calculation.appendSign();
				type=2;
				//직전 숫자만 삭제
				System.out.println("부호전환");
				break;
			case"=":
				calculation.detectEqual();
				type=1;
				//직전 숫자만 삭제
				System.out.println("계산");
				break;
			case"\u232B":
				calculation.detectBackSpace();
				type=2;
				System.out.println("백스페이스");
				break;	
			case"÷": case"×": case"+": case"-":
				//직전 숫자만 삭제
				calculation.detectOperator(character);
				type=1;
				System.out.println("연산자");
				break;
			default:
				calculation.detectNumber(character);
				type=2;
				System.out.println("숫자");
				break;
		}
		textPanel.setPresentNumberText(calculation.status.getNumber(),type);
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
				if(button.getBackground().toString().equals("java.awt.Color[r=240,g=240,b=240]"))
					loadLogFrame();
				else
					loadCalculatorFrame();
			}
		}
	}
	public class deleteButtonActionListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			JButton button=null;
			if(e.getSource() instanceof JButton) {
				button=(JButton)e.getSource();
			}
			if(button!=null) {
				String text=button.getText().replace("<html>","").replace("</font></html>","").replace("<font size=6>","").replace(",", "");
				String[] temp=text.split("<br>");
				calculation.status.setNumber(temp[1]);
				calculation.status.setUpField(temp[0]);
				calculation.status.setIsLog(true);
				calculation.status.setLastType(Constant.TYPE_EQUAL);
				textPanel.setPresentNumberText(calculation.status.getNumber(),2);
				textPanel.setLogNumberText(calculation.status.getUpFieldText());
				loadCalculatorFrame();
			}
				
		}
	}
}
