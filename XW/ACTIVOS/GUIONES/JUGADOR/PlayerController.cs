using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, camSensitivity, gravityModifier, jumpPower, jumpDoublePower, runSpeed,AIMSpeed,maxViewAngle=60f;
    public CharacterController character;
    private Vector3 moveInput,gunStartPos;
    public Transform cam, groundCheckPoint, firePoint,firePoint2,firePoint3,firePoint4,firePoint5,firePoint6,firePoint7,AIMPoint,GunHolder;
    public LayerMask whatIsGround;
    public bool invertX, invertY, canJump, canDoubleJump;
    public Animator animator;
    public static PlayerController player;
    public Gun activateGun;
    public List<Gun> allGuns = new List<Gun>();
    public List<BulletPool> allBullets = new List<BulletPool>();
    public List<Gun> unlockableGuns = new List<Gun>();
    public List<BulletPool> unlockableBullets = new List<BulletPool>();
    public int currentGun,currentBullet;
    public BulletPool activePool;
    public GameObject muzzleFlash,muzzleFlash2,muzzleFlash3,muzzleFlash4,muzzleFlash5,muzzleFlash6,muzzleFlash7;
    public AudioSource footstepFast, footstepSlow;
    private float bounceAmount;
    private bool bounce;
    // Start is called before the first frame update
    void Start()
    {
     muzzleFlash.SetActive(false); 
     muzzleFlash2.SetActive(false);
     muzzleFlash3.SetActive(false);
     muzzleFlash4.SetActive(false);
     muzzleFlash5.SetActive(false);
     muzzleFlash6.SetActive(false);
     muzzleFlash7.SetActive(false);
     player = this;
     UIController.UI.ammoText.text = "AMMO: " + activateGun.currentAmmo;
     activateGun = allGuns[currentGun];
     activePool = allBullets[currentBullet];
     activateGun.gameObject.SetActive(true);
     gunStartPos = GunHolder.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
     if (!UIController.UI.pauseScreen.activeInHierarchy&& !GameManager.manager.ending) 
     {
      float yStore = moveInput.y;
      Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
      Vector3 HoriMove= transform.right * Input.GetAxis("Horizontal");
      moveInput =HoriMove + vertMove;
      moveInput.Normalize();
      if (Input.GetButton("Run")) 
      {
       moveInput = moveInput * runSpeed;
      }
      else
      {
       moveInput = moveInput * moveSpeed;
      }
      moveInput.y = yStore;
      moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;
      if (character.isGrounded) 
      {
       moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
      }
      canJump =character.isGrounded;
      if (canJump) 
      {
       canDoubleJump = false;
      }
      if (Input.GetButtonDown("Jump")&& canJump) 
      {
       moveInput.y = jumpPower;
       canDoubleJump = true;
       AudioManager.AM.PlaySFX(8);
      } 
      else if(Input.GetButtonDown("Jump") && canDoubleJump) 
      {
       moveInput.y = jumpDoublePower;
       canDoubleJump = false;
       AudioManager.AM.PlaySFX(8);
      }
      if (bounce) 
      {
       bounce = false;
       moveInput.y = bounceAmount;
       canDoubleJump = true;         
      }
      character.Move(moveInput*Time.deltaTime);
      Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"))*camSensitivity;
      if (invertX) 
      {
       mouseInput.x = -mouseInput.x;   
      }
      if (invertY)
      {
       mouseInput.y = -mouseInput.y;
      }
      transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
      cam.rotation = Quaternion.Euler(cam.rotation.eulerAngles + new Vector3(mouseInput.y, 0f, 0f));
      if (cam.rotation.eulerAngles.x > maxViewAngle && cam.rotation.eulerAngles.x < 180f) 
      { 
       cam.rotation = Quaternion.Euler(maxViewAngle, cam.rotation.eulerAngles.y, cam.rotation.eulerAngles.z);      
      }
      else if (cam.rotation.eulerAngles.x > 180f && cam.rotation.eulerAngles.x < 360f - maxViewAngle) 
      {
       cam.rotation = Quaternion.Euler(-maxViewAngle, cam.rotation.eulerAngles.y, cam.rotation.eulerAngles.z);
      }
      muzzleFlash.SetActive(false);
      muzzleFlash2.SetActive(false);
      muzzleFlash3.SetActive(false);
      muzzleFlash4.SetActive(false);
      muzzleFlash5.SetActive(false);
      muzzleFlash6.SetActive(false);
      muzzleFlash7.SetActive(false);
      if (Input.GetMouseButtonDown(0)&& activateGun.fireCounter<=0) 
      {
       RaycastHit hit;
       if(Physics.Raycast(cam.position,cam.forward,out hit, 50f)) 
       {
        if (Vector3.Distance(cam.position, hit.point) > 2f) 
        {
         firePoint.LookAt(hit.point);
         firePoint2.LookAt(hit.point);
         firePoint3.LookAt(hit.point);
         firePoint4.LookAt(hit.point);
         firePoint5.LookAt(hit.point);
         firePoint6.LookAt(hit.point);
         firePoint7.LookAt(hit.point);
        }
       }
       else 
       {
        firePoint.LookAt(cam.position + (cam.forward * 30f));
        firePoint2.LookAt(cam.position + (cam.forward * 30f));
        firePoint3.LookAt(cam.position + (cam.forward * 30f));
        firePoint4.LookAt(cam.position + (cam.forward * 30f));
        firePoint5.LookAt(cam.position + (cam.forward * 30f));
        firePoint6.LookAt(cam.position + (cam.forward * 30f));
        firePoint7.LookAt(cam.position + (cam.forward * 30f));
       }
       FireShot();
      }
      if (Input.GetMouseButton(0) && activateGun.canAutoFire) 
      {
       if (activateGun.fireCounter <= 0) 
       {
        FireShot();      
       }   
      }
      if (Input.GetButtonDown("Switch")) 
      {
       SwitchGun();   
      }
      if (Input.GetMouseButtonDown(1)) 
      {
       CameraController.click.ZoomIn(activateGun.zoomAmount);   
      }
      if (Input.GetMouseButton(1)) 
      {  
       GunHolder.position = Vector3.MoveTowards(GunHolder.position, AIMPoint.position, AIMSpeed * Time.deltaTime);   
      }
      else 
      {
       GunHolder.localPosition = Vector3.MoveTowards(GunHolder.localPosition, gunStartPos, AIMSpeed * Time.deltaTime);
      }
      if (Input.GetMouseButtonUp(1)) 
      {
       CameraController.click.ZoomOut();   
      }
      animator.SetFloat("moveSpeed", moveInput.magnitude);
      animator.SetBool("onGround",canJump);
     } 
    }
    public void FireShot() 
    {
     if (activateGun.currentAmmo > 0) 
     {
      activateGun.currentAmmo--;
      if (currentBullet == 0 && currentGun == 0) 
      { 
       GameObject bullet = BulletPool.pool.GetPooledObject();
       if (bullet != null) 
       {
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);
        muzzleFlash.SetActive(true);
       }     
      }
      if (currentBullet == 1 && currentGun == 1) 
      { 
       GameObject bullet1 = BulletPool.pool.GetPooledObject2();
       if (bullet1 != null)
       {
        bullet1.transform.position = firePoint2.position;
        bullet1.transform.rotation = firePoint2.rotation;
        bullet1.SetActive(true);
        muzzleFlash2.SetActive(true);
       }     
      }
      if (currentBullet == 2 && currentGun == 2)
      {
      GameObject bullet2 = BulletPool.pool.GetPooledObject3();
       if (bullet2 != null)
       {
        bullet2.transform.position = firePoint3.position;
        bullet2.transform.rotation = firePoint3.rotation;
        bullet2.SetActive(true);
        muzzleFlash3.SetActive(true);
       }
      }
      if (currentBullet == 3 && currentGun == 3)
      {
       GameObject bullet3 = BulletPool.pool.GetPooledObject4();
       if (bullet3 != null)
       {
        bullet3.transform.position = firePoint4.position;
        bullet3.transform.rotation = firePoint4.rotation;
        bullet3.SetActive(true);
        muzzleFlash4.SetActive(true);
       }
      }
      if (currentBullet == 4 && currentGun == 4)
      {
       GameObject bullet4 = BulletPool.pool.GetPooledObject5();
       if (bullet4 != null)
       {
        bullet4.transform.position = firePoint5.position;
        bullet4.transform.rotation = firePoint5.rotation;
        bullet4.SetActive(true);
        muzzleFlash5.SetActive(true);
       }
      }
      if (currentBullet == 5 && currentGun == 5)
      {
       GameObject bullet5 = BulletPool.pool.GetPooledObject6();
       if (bullet5 != null)
       {
        bullet5.transform.position = firePoint6.position;
        bullet5.transform.rotation = firePoint6.rotation;
        bullet5.SetActive(true);
        muzzleFlash6.SetActive(true);
       }
      }
      if (currentBullet == 6 && currentGun == 6)
      {
       GameObject bullet6 = BulletPool.pool.GetPooledObject7();
       if (bullet6 != null)
       {
        bullet6.transform.position = firePoint7.position;
        bullet6.transform.rotation = firePoint7.rotation;
        bullet6.SetActive(true);
        muzzleFlash7.SetActive(true);
       }
      }
      activateGun.fireCounter = activateGun.fireRate;
      UIController.UI.ammoText.text = "AMMO: " + activateGun.currentAmmo;
     }  
    }
    public void SwitchGun() 
    {
     activateGun.gameObject.SetActive(false);
     activePool.gameObject.SetActive(false);
     currentGun++;
     if (currentGun >= allGuns.Count) 
     {
      currentGun = 0;   
     }
     currentBullet++;
     if (currentBullet >= allBullets.Count) 
     {
      currentBullet = 0;   
     }
     activateGun = allGuns[currentGun];
     activateGun.gameObject.SetActive(true);
     activePool.gameObject.SetActive(true);
     activePool = allBullets[currentBullet];
     UIController.UI.ammoText.text = "AMMO: " + activateGun.currentAmmo;
    }
    public void AddGun(string gunToAdd)
    {
     bool gunUnlock = false;
     if (unlockableGuns.Count > 0 ) 
     { 
      for(int i = 0; i < unlockableGuns.Count; i++) 
      {
       gunUnlock = true;
       allGuns.Add(unlockableGuns[i]);
       unlockableGuns.RemoveAt(i);
       i = unlockableGuns.Count;
      }
     }
     if (gunUnlock) 
     {
      currentGun = allGuns.Count-2;
      SwitchGun();
     }
    }
    public void AddBullet(string bulletToAdd) 
    {
     bool bulletUnlock = false;
     if (unlockableBullets.Count > 0)
     {     
      for (int i = 0; i < unlockableBullets.Count; i++)
      {
       bulletUnlock = true;
       allBullets.Add(unlockableBullets[i]);
       unlockableBullets.RemoveAt(i);
       i = unlockableBullets.Count;
      }
     }
     if (bulletUnlock)
     {
      currentBullet = allBullets.Count-1;
      SwitchGun();
     }
    }
    public void Bounce(float bounceForce) 
    {
     bounceAmount = bounceForce;
     bounce = true;
    }
}
