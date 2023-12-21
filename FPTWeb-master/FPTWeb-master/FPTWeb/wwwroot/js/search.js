
const searchIcon = document.getElementById('search-icon');

// Lấy phần tử search box
const searchBox = document.getElementById('search-box');

// Thêm sự kiện click cho search icon
searchIcon.addEventListener('click', function() {
    // Lấy vị trí của search icon
    const iconRect = searchIcon.getBoundingClientRect();

    // Đặt vị trí cho search box dựa trên vị trí của search icon
    searchBox.style.top = iconRect.bottom + 'px';
    searchBox.style.left = iconRect.left + 'px';

    // Đảo ngược lớp show để hiển thị hoặc ẩn search box
    searchBox.classList.toggle('show');
});