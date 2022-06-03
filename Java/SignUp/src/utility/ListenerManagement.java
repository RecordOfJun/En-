package utility;

import java.awt.Font;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class ListenerManagement {
	public static ListenerManagement instance;
	
	private ListenerManagement() {};
	
	public static synchronized ListenerManagement getInstance() {
		if(instance==null)
			instance=new ListenerManagement();
		return instance;
	}
	
	public void linkPasswordFocusEvent(String defaultText,JPasswordField textField) {
		textField.addFocusListener(new passwordFocusEvent(defaultText, textField));
	}
	
	public void linkTextFocusEvent(String defaultText,JTextField textField) {
		textField.addFocusListener(new textFocusEvent(defaultText, textField));
	}
	
	public void linkTextLengthLimited(int maxLength,JTextField textField) {
		textField.addKeyListener(new setTextLengthLimited(maxLength));
	}
	
	public class setTextLengthLimited extends KeyAdapter{
		int maxLength;
		
		public setTextLengthLimited(int maxLength) {
			this.maxLength=maxLength;
		}
		
		public void keyTyped(KeyEvent e) {
			JTextField textField=(JTextField)e.getComponent();
			if(textField.getText().length()>maxLength) {
				e.consume();
				textField.setText(textField.getText().substring(0,maxLength-1));
			}
			else if(textField.getText().length()>=maxLength)
				e.consume();
		}
	}
	
	public class textFocusEvent implements FocusListener{
		String defaultText;
		JTextField textField;
		
		public textFocusEvent(String defaultText,JTextField textField) {
			this.defaultText=defaultText;
			this.textField=textField;
		}
		
		public void focusGained(FocusEvent e) {
			if(textField.getText().equals(defaultText)) {
				textField.setText("");
				textField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
			}
		}

		public void focusLost(FocusEvent e) {
			if(textField.getText().length()==0) {
				textField.setFont(new Font("맑은 고딕",Font.PLAIN,10));
				textField.setText(defaultText);
			}
		}
	}
	
	public class passwordFocusEvent implements FocusListener{
		String defaultText;
		JPasswordField textField;
		
		public passwordFocusEvent(String defaultText,JPasswordField textField) {
			this.defaultText=defaultText;
			this.textField=textField;
		}
		
		public void focusGained(FocusEvent e) {
			if(String.valueOf(textField.getPassword()).equals(defaultText)) {
				textField.setEchoChar('*');
			}
		}

		public void focusLost(FocusEvent e) {
			if(String.valueOf(textField.getPassword()).length()==0) {
				textField.setEchoChar((char)0);
			}
		}
		
	}
}
